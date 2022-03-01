using System;
using System.Collections.Generic;
using System.Linq;
using RentCarApp.Domain.Cars.Roles;
using RentCarApp.Domain.SeedWork;
using RentCarApp.Domain.SharedKernel;

namespace RentCarApp.Domain.Cars.ValueObjects
{
    public class ModelYearValue : ValueObject
    {
        public int Year { get; }


        private ModelYearValue(int year)
        {
            this.Year = year;
        }

        public static ModelYearValue Of(int year)
        {
            CheckRule(new ModelYearValueMustBeValidRule(year));

            return new ModelYearValue(year);
        }

        public static ModelYearValue Of(ModelYearValue yearValueObject)
        {
            return new ModelYearValue(yearValueObject.Year);
        }
    }

}