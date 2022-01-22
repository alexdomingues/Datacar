using Datacar.Client.Helpers;
using Datacar.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datacar.Client.Repository
{
    public class UserRepository : IUsersRepository
    {
        private readonly IHttpService httpService;
        private readonly string url = "api/users";

        public UserRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<PaginatedResponse<List<UserInfo>>> GetUsers(PaginationDTO paginationDTO)
        {
            return await httpService.GetHelper<List<UserInfo>>(url, paginationDTO);
        }

        public async Task<UserInfo> GetUserById(string userId)
        {
            var response = await httpService.Get<UserInfo>($"{url}/GetUserById/{userId}");

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }
        public async Task<ApplicationUser> GetUserByName(string userName)
        {
            var response = await httpService.Get<ApplicationUser>($"{url}/GetUserByName/{userName}");

            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }


        public async Task UpdateUser(UserInfo user)
        {
            var response = await httpService.Put(url, user);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task ChangePassword(ChangePasswordDTO userPass)
        {
            var response = await httpService.Post(url, userPass);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }            
        }

        public async Task DeleteUser(string userId)
        {
            var response = await httpService.Delete($"{url}/{userId}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<List<RoleDTO>> GetRoles()
        {
            return await httpService.GetHelper<List<RoleDTO>>($"{url}/roles");
        }

        public async Task AssignRole(EditRoleDTO editRole)
        {
            var response = await httpService.Post($"{url}/assignRole", editRole);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task RemoveRole(EditRoleDTO editRole)
        {
            var response = await httpService.Post($"{url}/removeRole", editRole);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
