using Datacar.Server.Helpers;
using Datacar.Shared.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Datacar.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountsController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserInfo model)
        {            
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                // new fields required by Datacar scope
                Language = model.Language,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                PostalCode = model.PostalCode,
                Local = model.Local,
                BornDate = model.BornDate,
                MobilePhoneNumber = model.MobilePhoneNumber,
                Comment = model.Comment,
                ExpireDate = model.ExpireDate
            };

            model.Password = Constants.DefaultPassword;

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                UserLoginDTO userLogin = new UserLoginDTO();
                userLogin.Email = model.Email;
                userLogin.Password = model.Password;
                return await BuildToken(userLogin);
            }
            else
            {
                return BadRequest("Username or password invalid");
            }
        }

        //[HttpPost("Login")]
        //public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo userInfo)
        //{
        //    var result = await _signInManager.PasswordSignInAsync(userInfo.Email,
        //        userInfo.Password, isPersistent: false, lockoutOnFailure: false);

        //    if (result.Succeeded)
        //    {
        //        return await BuildToken(userInfo);
        //    }
        //    else
        //    {
        //        return BadRequest("Invalid login attempt");
        //    }
        //}

        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserLoginDTO userLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(userLogin.Email,
                userLogin.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return await BuildToken(userLogin);
            }
            else
            {
                return BadRequest("Invalid login attempt");
            }
        }


        [HttpGet("RenewToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<UserToken>> Renew()
        {
            var userLogin = new UserLoginDTO()
            {
                Email = HttpContext.User.Identity.Name
            };

            return await BuildToken(userLogin);
        }

        private async Task<UserToken> BuildToken(UserLoginDTO userLogin)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userLogin.Email),
                new Claim(ClaimTypes.Email, userLogin.Email)                
            };

            var identityUser = await _userManager.FindByEmailAsync(userLogin.Email);
            var claimsDB = await _userManager.GetClaimsAsync(identityUser);

            claims.AddRange(claimsDB);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddYears(1);

            JwtSecurityToken token = new JwtSecurityToken(
                  issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
