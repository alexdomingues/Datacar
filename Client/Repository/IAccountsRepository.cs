using Datacar.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datacar.Client.Repository
{
    public interface IAccountsRepository
    {
        Task<UserToken> Login(UserLoginDTO userLogin);
        Task<UserToken> Register(UserInfo userInfo);
        Task<UserToken> RenewToken();
    }
}
