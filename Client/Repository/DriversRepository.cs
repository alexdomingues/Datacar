using Datacar.Client.Helpers;
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
            var response = await httpService.Get<Drivers>($"{url}/edit/{driverId}");

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task<List<Drivers>> GetDrivers()
        {
            var response = await httpService.Get<List<Drivers>>(url);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
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
    }
}
