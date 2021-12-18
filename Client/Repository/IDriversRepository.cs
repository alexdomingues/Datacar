using Datacar.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Datacar.Client.Repository
{
    public interface IDriversRepository
    {
        Task CreateDriver(Drivers driver);
        Task<List<Drivers>> GetDrivers();
        Task<Drivers> GetDriverById(int driverId);
        Task UpdateDriver(Drivers driver);
    }
}
