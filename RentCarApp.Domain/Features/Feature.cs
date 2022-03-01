using System;
using RentCarApp.Domain.Cities.Rules;
using RentCarApp.Domain.SeedWork;

namespace RentCarApp.Domain.Features
{
    public class Feature : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string nameAr { get; set; }
        public string nameEn { get; set; }
    }
}
