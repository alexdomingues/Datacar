using Datacar.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Datacar.Client.Repository
{
    public interface IDatacarUserRepository
    {
        Task CreateUser(DatacarUser datacarUser);
        Task<DatacarUser> GetUserById(int userId);
        Task<List<DatacarUser>> GetUsers();
        Task DeleteUser(int userId);
        Task UpdateUser(DatacarUser user);
    }
}
