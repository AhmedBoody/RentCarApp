using RentCarApp.Application.Configuration.Commands;
using RentCarApp.Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Application.Cities.List
{
    public class ListCityQuery : IQuery<List<CityDto>>
    {
        public string Filter { get; }

        public ListCityQuery(string filter)
        {
            this.Filter = filter;
        }
    }
}
