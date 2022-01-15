using Datacar.Server.Helpers;
using Datacar.Shared.DTOs;
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
        // We use input parameter for pagination and [FromQuery] because we are going to use query string
        public async Task<ActionResult<List<Drivers>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = context.Drivers.AsQueryable();
            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);

            //var listDrivers = await context.Drivers.ToListAsync();
            var listDriversPaginated = await queryable.Paginate(paginationDTO).ToListAsync();

            if (listDriversPaginated == null)
            {
                return NotFound();
            }
            return listDriversPaginated;
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
        public async Task<ActionResult<Drivers>> Put(Drivers driver)
        {
            context.Attach(driver).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var driver = await context.Drivers.FirstOrDefaultAsync(x => x.Id == id);
            if (driver == null)
            {
                return NotFound();
            }
            context.Remove(driver);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
