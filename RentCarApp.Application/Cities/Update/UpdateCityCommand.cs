using RentCarApp.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Application.Cities.Update
{
    public class UpdateCityCommand : CommandBase<CityDto>
    {
        public string NameEn { get; }
        public string NameAr { get; }
        public Guid CityId { get; }

        public UpdateCityCommand(string nameAr, string nameEn,Guid cityId)
        {
            this.NameAr = nameAr;
            this.NameEn = nameEn;
            this.CityId = cityId;
        }
    }
}
