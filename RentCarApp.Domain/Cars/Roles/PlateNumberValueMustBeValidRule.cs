using System;
using System.Linq;
using RentCarApp.Domain.Cars.Services;
using RentCarApp.Domain.SeedWork;

namespace RentCarApp.Domain.SharedKernel
{
    public class PlateNumberValueMustBeValidRule : IBusinessRule
    {
        private readonly string _plateNumber;
        private readonly string _id;
        private readonly IPlateNumberUniquenessChecker _plateNumberUniquenessChecker;

        public PlateNumberValueMustBeValidRule(string plateNumber, string id, IPlateNumberUniquenessChecker plateNumberUniquenessChecker)
        {
            _plateNumber = plateNumber;
            _id = id;
            _plateNumberUniquenessChecker = plateNumberUniquenessChecker;
        }

        public bool IsBroken()
        {
           var isUnique =  _plateNumberUniquenessChecker.IsUnique(_plateNumber, _id);
            ///Plate Number must have 3 no & 3 char & 1 space '133 KOL'
            
            if ( !isUnique                                                            ||
                 string.IsNullOrEmpty(_plateNumber)                                   ||
                _plateNumber.ToCharArray().Length != 7                                || 
                _plateNumber.ToCharArray().ToList().Count(c => Char.IsNumber(c)) != 3 ||
                _plateNumber.ToCharArray().ToList().Count(c => Char.IsLetter(c)) != 3   ) 
                return false;
            return true;
        }

        public string Message => "PlateNumber value must be  valid value";
    }
}