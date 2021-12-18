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
    public class DriversController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IFileStorageService fileStorageService;

        public DriversController(ApplicationDBContext context, IFileStorageService fileStorageService)
        {
            this.context = context;
            this.fileStorageService = fileStorageService;
        }

        [HttpGet("{driverId}")]
        public async Task<ActionResult<Drivers>> Get(int driverId)
        {
            var driverinfo = await context.Drivers.FirstOrDefaultAsync(x => x.Id == driverId);
            if (driverinfo == null)
            {
                return NotFound();
            }

            return driverinfo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Drivers>>> Get()
        {
            var listDrivers = await context.Drivers.ToListAsync();
            if (listDrivers == null)
            {
                return NotFound();
            }
            return listDrivers;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Drivers driver)
        {
            if (!string.IsNullOrWhiteSpace(driver.Photo))
            {
                var driverPhoto = Convert.FromBase64String(driver.Photo);
                driver.Photo = await fileStorageService.SaveFile(driverPhoto, ".jpg", "drivers");
            }
            context.Add(driver);
            await context.SaveChangesAsync();
            return driver.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Drivers driver)
        {
            context.Attach(driver).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
