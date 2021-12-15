using Datacar.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Datacar.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriversController
    {
        private readonly ApplicationDBContext context;
        public DriversController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Drivers driver)
        {
            context.Add(driver);
            await context.SaveChangesAsync();
            return driver.Id;
        }
    }
}
