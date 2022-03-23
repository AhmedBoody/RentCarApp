using System;
using System.Collections.Generic;
using System.Linq;
using RentCarApp.Domain.Cars.Roles;
using RentCarApp.Domain.Cars.Services;
using RentCarApp.Domain.SeedWork;
using RentCarApp.Domain.SharedKernel;

namespace RentCarApp.Domain.Cars.ValueObjects
{
    public class PlateNumberValue : ValueObject
    {
        public string PlateNumber { get; }
        private readonly IPlateNumberUniquenessChecker _plateNumberUniquenessChecker;
        private PlateNumberValue(string plateNumber, IPlateNumberUniquenessChecker plateNumberUniquenessChecker)
        {
            this.PlateNumber = plateNumber;
            this._plateNumberUniquenessChecker = plateNumberUniquenessChecker;
        }
        private PlateNumberValue(string plateNumber, string carId)
        {
            CheckRule(new PlateNumberValueMustBeValidRule(plateNumber, carId, _plateNumberUniquenessChecker));

        }
        public static PlateNumberValue Of(string plateNumber, string carId)
        {
            
            return new PlateNumberValue(plateNumber, carId);
        }

    }

}