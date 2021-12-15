using Datacar.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Datacar.Client.Repository
{
    public interface ICarsRepository
    {
        Task<List<Cars>> GetCars();
        Task CreateCar(Cars car);
        
    }
}
