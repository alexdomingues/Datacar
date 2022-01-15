using Datacar.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Datacar.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class DatacarUserController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        public DatacarUserController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<DatacarUser>> Get(int userId)
        {
            var userInfo = await context.DatacarUser.FirstOrDefaultAsync(x => x.Id == userId);
            if (userInfo == null)
            {
                return NotFound();
            }
            return userInfo;
        }

        [HttpGet]
        public async Task<ActionResult<List<DatacarUser>>> Get()
        {
            return await context.DatacarUser.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(DatacarUser datacarUser)
        {
            context.Add(datacarUser);
            await context.SaveChangesAsync();
            return datacarUser.Id;
        }

        [HttpPut]
        public async Task<ActionResult<DatacarUser>> Put(DatacarUser datacarUser)
        {
            context.Attach(datacarUser).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await context.DatacarUser.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            context.Remove(user);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
