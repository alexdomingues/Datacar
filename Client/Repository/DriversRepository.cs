using Datacar.Client.Helpers;
using Datacar.Shared.DTOs;
using Datacar.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Datacar.Client.Repository
{
    public class DriversRepository: IDriversRepository
    {
        private readonly IHttpService httpService;
        //endpoint where the controller is located
        public string url = "api/drivers";

        public DriversRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<Drivers> GetDriverById(int driverId)
        {
            var response = await httpService.Get<Drivers>($"{url}/{driverId}");

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        //Get the whole list of drivers
        //public async Task<List<Drivers>> GetDrivers()
        //{
        //    var response = await httpService.Get<List<Drivers>>(url);
        //    if (!response.Success)
        //    {
        //        throw new ApplicationException(await response.GetBody());
        //    }
        //    return response.Response;
        //}

        // Get the list of drivers paginated
        public async Task<PaginatedResponse<List<Drivers>>> GetDrivers(PaginationDTO paginationDTO)
        {
            return await httpService.GetHelper<List<Drivers>>(url, paginationDTO);
        }

        public async Task CreateDriver(Drivers driver)
        {
            var response = await httpService.Post(url, driver);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task UpdateDriver(Drivers driver)
        {
            var response = await httpService.Put(url, driver);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task DeleteDriver(int driverId)
        {
            var response = await httpService.Delete($"{url}/{driverId}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
