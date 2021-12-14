using Datacar.Client.Helpers;
using Datacar.Shared.Entities;
using System;
using System.Threading.Tasks;

namespace Datacar.Client.Repository
{
    public class UsersRepository: IUsersRepository
    {
        private readonly IHttpService httpService;

        public string url = "api/users";

        public UsersRepository(IHttpService httpService)
        {
            this.httpService = httpService;
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
