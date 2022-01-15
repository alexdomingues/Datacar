using Datacar.Server.Helpers;
using Datacar.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class CarsController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        public CarsController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet("{carId}")]
        public async Task<ActionResult<Cars>> Get(int carId)
        {
            var carInfo = await context.Cars.FirstOrDefaultAsync(x => x.Id == carId);
            if (carInfo == null)
            {
                return NotFound();
            }
            return carInfo;
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
        
        [HttpPut]
        public async Task<ActionResult<Cars>> Put(Cars car)
        {
            context.Attach(car).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
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
