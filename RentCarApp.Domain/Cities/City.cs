using System;
using RentCarApp.Domain.Cities.Rules;
using RentCarApp.Domain.SeedWork;

namespace RentCarApp.Domain.Cities
{
    public class City : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string nameAr { get; set; }
        public string nameEn { get; set; }
        public City()
        {
            //Only For EF.
        }
        public City(string nameAr, string nameEn,string id = null)
        {
            this.Id = string.IsNullOrEmpty(id) ? Guid.NewGuid() : Guid.Parse(id);
            this.nameAr = nameAr;
            this.nameEn = nameEn;
        }

        public static City CreateCity(string arabicName, string englishName, ICityUniquenessChecker _cityUniquenessChecker)
        {
            CheckRule(new CityUniquenessNameRole(_cityUniquenessChecker, arabicName, englishName));
            return new City(arabicName, englishName);
        }

        public static City UpdateCity(Guid id,string arabicName, string englishName, ICityUniquenessChecker _cityUniquenessChecker)
        {
            CheckRule(new CityUniquenessNameRole(_cityUniquenessChecker, arabicName, englishName,id.ToString()));
            return new City(arabicName, englishName,id.ToString());
        }
    }
}
