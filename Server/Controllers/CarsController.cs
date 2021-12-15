using Datacar.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Datacar.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController
    {
        private readonly ApplicationDBContext context;
        public CarsController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Cars car)
        {
            context.Add(car);
            await context.SaveChangesAsync();
            return car.Id;
        }
    }
}
