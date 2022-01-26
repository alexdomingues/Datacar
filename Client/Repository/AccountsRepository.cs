using Datacar.Client.Helpers;
using Datacar.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datacar.Client.Repository
{
    public class AccountsRepository: IAccountsRepository
    {
        private readonly IHttpService httpService;
        private readonly string baseURL = "api/accounts";

        public AccountsRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }


        public async Task<UserToken> Register(UserInfo userInfo)
        {
            var httpResponse = await httpService.Post<UserInfo, UserToken>($"{baseURL}/create", userInfo);

            if (!httpResponse.Success)
            {
                throw new ApplicationException(await httpResponse.GetBody());
            }

            return httpResponse.Response;
        }

        //public async Task<UserToken> Login(UserInfo userInfo)
        //{
        //    var httpResponse = await httpService.Post<UserInfo, UserToken>($"{baseURL}/login", userInfo);

        //    if (!httpResponse.Success)
        //    {
        //        throw new ApplicationException(await httpResponse.GetBody());
        //    }

        //    return httpResponse.Response;
        //}

        public async Task<UserToken> Login(UserLoginDTO userLogin)
        {
            var httpResponse = await httpService.Post<UserLoginDTO, UserToken>($"{baseURL}/login", userLogin);

            if (!httpResponse.Success)
            {
                throw new ApplicationException(await httpResponse.GetBody());
            }

            return httpResponse.Response;
        }

        public async Task<UserToken> RenewToken()
        {
            var response = await httpService.Get<UserToken>($"{baseURL}/RenewToken");

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }
    }
}
