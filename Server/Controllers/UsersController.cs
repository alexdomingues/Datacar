using Datacar.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<ActionResult<int>> Post(Users user)
        {
            context.Add(user);
            await context.SaveChangesAsync();
            return user.Id;
        }
    }
}
