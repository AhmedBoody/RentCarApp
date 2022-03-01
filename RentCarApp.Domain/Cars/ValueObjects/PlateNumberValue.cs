using System;
using System.Collections.Generic;
using System.Linq;
using RentCarApp.Domain.SeedWork;
using RentCarApp.Domain.SharedKernel;

namespace RentCarApp.Domain.Cars.ValueObjects
{
    public class PlateNumberValue : ValueObject
    {
        public string PlateNumber { get; }


        private PlateNumberValue(string plateNumber)
        {
            this.PlateNumber = plateNumber;
        }

        public static PlateNumberValue Of(string plateNumber)
        {
           // CheckRule(new ModelYearValueMustBeValidRule(year));

            return new PlateNumberValue(plateNumber);
        }

        public static PlateNumberValue Of(PlateNumberValue yearValueObject)
        {
            return new PlateNumberValue(yearValueObject.PlateNumber);
        }
    }

}