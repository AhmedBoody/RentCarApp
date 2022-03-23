using System;
using RentCarApp.Domain.Cities.Rules;
using RentCarApp.Domain.Manufacturers;
using RentCarApp.Domain.SeedWork;

namespace RentCarApp.Domain.Cities
{
    public class CarModel : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string nameAr { get; set; }
        public string nameEn { get; set; }
        public Guid manufactureId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int CarCounter { get; set; }
        
    }
}
