using Datacar.Shared.DTOs;
using Datacar.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Datacar.Client.Repository
{
    public interface IDriversRepository
    {
        Task CreateDriver(Drivers driver);
        Task<PaginatedResponse<List<Drivers>>> GetDrivers(PaginationDTO paginationDTO);
        Task<Drivers> GetDriverById(int driverId);
        Task UpdateDriver(Drivers driver);
        Task DeleteDriver(int driverId);
    }
}
