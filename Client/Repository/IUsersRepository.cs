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
        Task<List<RoleDTO>> GetRoles();
        Task<PaginatedResponse<List<UserDTO>>> GetUsers(PaginationDTO paginationDTO);
        Task RemoveRole(EditRoleDTO editRole);
    }
}
