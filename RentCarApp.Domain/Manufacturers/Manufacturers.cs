using System;
using System.Collections.Generic;
using RentCarApp.Domain.Cities;
using RentCarApp.Domain.Cities.Rules;
using RentCarApp.Domain.SeedWork;

namespace RentCarApp.Domain.Manufacturers
{
    public class Manufacturer : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string nameAr { get; set; }
        public string nameEn { get; set; }
        public List<CarModel> CarModels { get; set; }
    }
}
