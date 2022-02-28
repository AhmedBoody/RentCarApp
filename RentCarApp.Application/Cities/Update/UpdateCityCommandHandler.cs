using RentCarApp.Application.Configuration.Commands;
using RentCarApp.Domain.Cities;
using RentCarApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace RentCarApp.Application.Cities.Update
{
    public class UpdateCityCommandHandler : ICommandHandler<UpdateCityCommand, CityDto>
    {
        private readonly IRepository<City> _cityRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICityUniquenessChecker _cityUniquenessChecker;

        public UpdateCityCommandHandler(IRepository<City> cityRepository, ICityUniquenessChecker cityUniquenessChecker, IUnitOfWork unitOfWork)
        {
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
            _cityUniquenessChecker = cityUniquenessChecker;
        }

        public async Task<CityDto> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetFirstOrDefaultAsync(r => r.Id == request.CityId);

            if (city == null)
                throw new KeyNotFoundException("no city for this Id");

            var updatedCity = City.UpdateCity(city.Id, request.NameAr, request.NameEn, _cityUniquenessChecker);
            _cityRepository.Update(updatedCity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new CityDto
            {
                Id = city.Id
            };
        }
    }
}
