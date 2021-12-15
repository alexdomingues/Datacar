using Datacar.Client.Helpers;
using Datacar.Shared.Entities;
using System;
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

        public async Task CreateDriver(Drivers driver)
        {
            var response = await httpService.Post(url, driver);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
