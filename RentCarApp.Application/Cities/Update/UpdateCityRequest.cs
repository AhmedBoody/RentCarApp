using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Application.Cities.Update
{
    public class UpdateCityRequest
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public Guid Id { get; set; }
    }
}
