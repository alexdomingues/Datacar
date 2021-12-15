using Datacar.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Datacar.Client.Repository
{
    public interface ICarsRepository
    {
        Task CreateCar(Cars car);
        Task<List<Cars>> GetCars();
    }
}
