using Datacar.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datacar.Client.Repository
{
    public interface IUsersRepository
    {
        Task AssignRole(EditRoleDTO editRole);
        Task DeleteUser(string userId);
        Task<List<RoleDTO>> GetRoles();
        Task<UserInfo> GetUserById(string userId);
        Task<PaginatedResponse<List<UserInfo>>> GetUsers(PaginationDTO paginationDTO);
        Task RemoveRole(EditRoleDTO editRole);
        Task UpdateUser(UserInfo user);
    }
}
