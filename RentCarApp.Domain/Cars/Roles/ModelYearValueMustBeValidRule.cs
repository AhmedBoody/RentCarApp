using System;
using RentCarApp.Domain.SeedWork;

namespace RentCarApp.Domain.Cars.Roles
{
    public class ModelYearValueMustBeValidRule : IBusinessRule
    {
        private readonly int _year;

        public ModelYearValueMustBeValidRule(int year)
        {
            _year = year;
        }

        public bool IsBroken()
        {
            ///we add 1 becuase its famous in car new year model
            ///be acialable before new year
            var minimumYear = 2010;
            var limitYear = DateTime.Now.Year + 1;
            if (_year > limitYear || _year < minimumYear)
                return false;
            else
                return true;
        }

        public string Message => "Money value must have currency";
    }
}