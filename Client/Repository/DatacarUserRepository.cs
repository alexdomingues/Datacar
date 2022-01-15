using Datacar.Client.Helpers;
using Datacar.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Datacar.Client.Repository
{
    public class DatacarUserRepository: IDatacarUserRepository
    {
        private readonly IHttpService httpService;
        //endpoint where the controller is located
        public string url = "api/datacaruser";

        public DatacarUserRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<DatacarUser> GetUserById(int userId)
        {
            var response = await httpService.Get<DatacarUser>($"{url}/{userId}");

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task<List<DatacarUser>> GetUsers()
        {
            var response = await httpService.Get<List<DatacarUser>>(url);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }
        public async Task CreateUser(DatacarUser user)
        {
            var response = await httpService.Post(url, user);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task UpdateUser(DatacarUser user)
        {
            var response = await httpService.Put(url, user);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task DeleteUser(int userId)
        {
            var response = await httpService.Delete($"{url}/{userId}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
