using Datacar.Shared.Entities;
using System;
using System.Collections.Generic;

namespace Datacar.Client.Helpers
{
    //class to implement the interface
    public class RepositoryInMemory : IRepository
    {
        public List<Drivers> GetDrivers()
        {
            return new List<Drivers>()
            {
                new Drivers() { Id=1,Name = "João" },
                new Drivers() { Id=2,Name = "Pedro" },
                new Drivers() { Id=3,Name = "Rui" }
            };
        }

        public List<Cars> GetCars()
        {
            return new List<Cars>()
            {
                new Cars() { Id=1,License = "90-CV-46", LicenseDate =  DateTime.Now , Model = "BMW", Type = "116i", InitialKms = 0, BuyKms=15000, ContractValidity=DateTime.Now, DriverId=1, TollIdentifier="123456"
                },
                new Cars() { Id=2,License = "90-JJ-43", LicenseDate =  DateTime.Now  , Model = "BMW", Type = "116i", InitialKms = 0, BuyKms=15000, ContractValidity=DateTime.Now, DriverId=1, TollIdentifier="123456"
                },
                new Cars() { Id=3,License = "44-CV-88", LicenseDate =  DateTime.Now , Model = "BMW", Type = "116i", InitialKms = 0, BuyKms=15000, ContractValidity=DateTime.Now, DriverId=1, TollIdentifier="123456"
                }
            };
        }

        public Cars GetCar(int carId)
        {
            return new Cars()
            {
                Id = 1,
                License = "90-CV-46",
                LicenseDate = DateTime.Now,
                Model = "BMW",
                Type = "116i",
                InitialKms = 0,
                BuyKms = 15000,
                ContractValidity = DateTime.Now,
                DriverId = 1,
                TollIdentifier = "123456"

            };
        }
    }
}
