using Datacar.Shared.Entities;
using System.Collections.Generic;

namespace Datacar.Client.Helpers
{
    // to abstract the obtation of the data
    public interface IRepository
    {
        //signature
        List<Drivers> GetDrivers();

        List<Cars> GetCars();

    }
}
