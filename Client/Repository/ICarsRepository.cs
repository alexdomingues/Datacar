using Datacar.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Datacar.Client.Repository
{
    public interface ICarsRepository
    {
        Task<List<Cars>> GetCars();
        Task CreateCar(Cars car);
        Task DeleteCar(int carId);
        Task UpdateCar(Cars car);
        Task<Cars> GetCarById(int carId);
    }
}
