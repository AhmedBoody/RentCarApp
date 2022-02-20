using RentCarApp.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Application.Cities.Create
{
    public class CreateCityCommand : CommandBase<CityDto>
    {
        public string NameEn { get; }

        public string NameAr { get; }

        public CreateCityCommand(string nameAr, string nameEn)
        {
            this.NameAr = nameAr;
            this.NameEn = nameEn;
        }
    }
}
