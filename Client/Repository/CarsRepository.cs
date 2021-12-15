using Datacar.Client.Helpers;
using Datacar.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Datacar.Client.Repository
{
    public class CarsRepository: ICarsRepository
    {
        private readonly IHttpService httpService;
        //endpoint where the controller is located
        public string url = "api/cars";

        public CarsRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<List<Cars>> GetCars()
        {
            var response = await httpService.Get<List<Cars>>(url);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task CreateCar(Cars car)
        {
            var response = await httpService.Post(url, car);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
