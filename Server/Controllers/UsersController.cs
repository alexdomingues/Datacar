using Datacar.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Datacar.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController: ControllerBase
    {
        private readonly ApplicationDBContext context;
        public UsersController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Users>>> Get()
        {
            return await context.Users.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(Users user)
        {
            context.Add(user);
            await context.SaveChangesAsync();
            return user.Id;
        }
    }
}
