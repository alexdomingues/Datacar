using Datacar.Server.Helpers;
using Datacar.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Datacar.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriversController
    {
        private readonly ApplicationDBContext context;
        private readonly IFileStorageService fileStorageService;

        public DriversController(ApplicationDBContext context, IFileStorageService fileStorageService)
        {
            this.context = context;
            this.fileStorageService = fileStorageService;
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
    }
}
