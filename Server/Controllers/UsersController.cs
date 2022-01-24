using Datacar.Server.Helpers;
using Datacar.Shared.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Datacar.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(ApplicationDBContext context,
            UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [Route("[action]/{userId}")]
        [HttpGet("{userId}")]
        public async Task<ActionResult<ApplicationUser>> GetUserById(string userId)
        {
            var userInfo = await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (userInfo == null)
            {
                return NotFound();
            }
            return userInfo;
        }

        [Route("[action]/{userName}")]
        [HttpGet("{userName}")]
        public async Task<ActionResult<ApplicationUser>> GetUserByName(string userName)
        {
            var userInfo = await userManager.FindByNameAsync(userName);
            if (userInfo == null)
            {
                return NotFound();
            }
            return userInfo;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserInfo>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = context.Users.AsQueryable();
            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);
            return await queryable.Paginate(paginationDTO)
              .Select(x => new UserInfo { FirstName = x.FirstName, MobilePhoneNumber = x.MobilePhoneNumber , Email = x.Email, UserId = x.Id }).ToListAsync();
        }

        [HttpPut]
        public async Task<ActionResult<ApplicationUser>> Put(UserInfo userInfo)
        {            
            var user = await userManager.FindByIdAsync(userInfo.UserId);
            // Update fields with changes
            user.Email = userInfo.Email;
            user.FirstName = userInfo.FirstName;
            user.LastName = userInfo.LastName;
            user.Address = userInfo.Address;
            user.PostalCode = userInfo.PostalCode;
            user.Local = userInfo.Local;
            user.Language = userInfo.Language;
            user.BornDate = userInfo.BornDate;
            user.PhoneNumber = userInfo.PhoneNumber;
            user.MobilePhoneNumber = userInfo.MobilePhoneNumber;
            user.Comment = userInfo.Comment;
            user.ExpireDate = userInfo.ExpireDate;

            await userManager.UpdateAsync(user);           
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordDTO userPass)
        {
            var user = await userManager.FindByIdAsync(userPass.UserId);

            if (user == null)
            {
                return NotFound();
            }
            else
            {   
                var result = await userManager.ChangePasswordAsync(user, userPass.CurrentPassword, userPass.NewPassword);

                if (!result.Succeeded)
                {
                    return BadRequest();
                }
                
                return NoContent();
            }
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> Delete(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                var result = await userManager.DeleteAsync(user);                
                return NoContent();
            }            
        }

        [HttpGet("roles")]
        public async Task<ActionResult<List<RoleDTO>>> Get()
        {
            return await context.Roles
                .Select(x => new RoleDTO { RoleName = x.Name }).ToListAsync();
        }

        [HttpPost("assignRole")]
        public async Task<ActionResult> AssignRole(EditRoleDTO editRoleDTO)
        {
            var user = await userManager.FindByIdAsync(editRoleDTO.UserId);
            await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, editRoleDTO.RoleName));
            return NoContent();
        }

        [HttpPost("removeRole")]
        public async Task<ActionResult> RemoveRole(EditRoleDTO editRoleDTO)
        {
            var user = await userManager.FindByIdAsync(editRoleDTO.UserId);            
            await userManager.RemoveClaimAsync(user, new Claim(ClaimTypes.Role, editRoleDTO.RoleName));
            return NoContent();
        }    
    }
}
