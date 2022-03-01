using System;
using RentCarApp.Domain.Cars.ValueObjects;
using RentCarApp.Domain.Cities.Rules;
using RentCarApp.Domain.SeedWork;
using RentCarApp.Domain.SharedKernel;

namespace RentCarApp.Domain.Cities
{
    public class Car : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public PlateNumberValue PlateNumber { get; private set; }
        public ModelYearValue ModelYear { get; private set; }
        public MoneyValue DailyRent { get; private set; }
        public MoneyValue WeeklyRent { get; private set; }
        public Guid CarModelId { get; private set; }
        public CarModel CarModel { get; private set; }  
        
        public Guid CarTypelId { get; private set; }
        public CarType CarType { get; private set; }    

        public Car()
        {
            //Only For EF.
        }
        //public Car(string nameAr, string nameEn,string id = null)
        //{
        //    this.Id = string.IsNullOrEmpty(id) ? Guid.NewGuid() : Guid.Parse(id);
        //    this.nameAr = nameAr;
        //    this.nameEn = nameEn;
        //}

        //public static City CreateCity(string arabicName, string englishName, ICityUniquenessChecker _cityUniquenessChecker)
        //{
        //    CheckRule(new CityUniquenessNameRole(_cityUniquenessChecker, arabicName, englishName));
        //    return new City(arabicName, englishName);
        //}

    }
}
