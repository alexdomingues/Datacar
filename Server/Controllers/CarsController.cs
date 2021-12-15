using Datacar.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        [HttpGet]
        public async Task<ActionResult<List<Cars>>> Get()
        {
            return await context.Cars.ToListAsync();
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
