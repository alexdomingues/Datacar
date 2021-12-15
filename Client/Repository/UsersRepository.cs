using Datacar.Client.Helpers;
using Datacar.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Datacar.Client.Repository
{
    public class UsersRepository: IUsersRepository
    {
        private readonly IHttpService httpService;
        //endpoint where the controller is located
        public string url = "api/users";

        public UsersRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<List<Users>> GetUsers()
        {
            var response = await httpService.Get<List<Users>>(url);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }
        public async Task CreateUser(Users user)
        {
            var response = await httpService.Post(url, user);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
