using Datacar.Shared.Entities;
using System.Threading.Tasks;

namespace Datacar.Client.Repository
{
    public interface IDriversRepository
    {
        Task CreateDriver(Drivers driver);
    }
}
