using Datacar.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Datacar.Client.Repository
{
    public interface IUsersRepository
    {
        Task CreateUser(Users user);
        Task<List<Users>> GetUsers();
    }
}
