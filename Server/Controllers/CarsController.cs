using Datacar.Server.Helpers;
using Datacar.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Datacar.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var car = await context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            context.Remove(car);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
