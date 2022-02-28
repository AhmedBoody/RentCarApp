using RentCarApp.Application.Cities.List;
using RentCarApp.Application.Configuration.Commands;
using RentCarApp.Application.Configuration.Queries;
using RentCarApp.Domain.Cities;
using RentCarApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace RentCarApp.Application.Cities.List
{
    public class ListCityQueryHandler : IQueryHandler<ListCityQuery, List<CityDto>>
    {
        private readonly IRepository<City> _cityRepository;
        public ListCityQueryHandler(IRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<List<CityDto>> Handle(ListCityQuery request, CancellationToken cancellationToken)
        {
            var filteredCities = await _cityRepository.GetAllNoTrackingAsync(r => string.IsNullOrEmpty(request.Filter)
            ||
            (r.nameEn.ToLower().Contains(request.Filter) || r.nameAr.ToLower().Contains(request.Filter)));

            if (filteredCities == null)
                return new List<CityDto>();

            return filteredCities.ToList().Select(s => new CityDto
            {
                Id = s.Id,
                NameAr = s.nameAr,
                NameEn = s.nameEn
            }).ToList();
        }
    }
}
