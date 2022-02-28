using RentCarApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Domain.Cities.Rules
{
    public class CityUniquenessNameRole : IBusinessRule
    {
        private readonly ICityUniquenessChecker _cityUniquenessChecker;
        private readonly string _cityArabicName;
        private readonly string _cityEnglishName;
        private readonly string _cityId;
        public CityUniquenessNameRole(ICityUniquenessChecker cityUniquenessChecker, string cityArabicName, string cityEnglishName, string cityId = null)
        {
            _cityUniquenessChecker = cityUniquenessChecker;
            _cityArabicName = cityArabicName;
            _cityEnglishName = cityEnglishName;
            _cityId = cityId;
        }
        public string Message => "City English & Arabic Names  must be Unique";

        public bool IsBroken()
        {
            return !_cityUniquenessChecker.IsUnique(_cityArabicName, _cityEnglishName,_cityId);
        }
    }
}
