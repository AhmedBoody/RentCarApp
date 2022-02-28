using RentCarApp.Application.Configuration.Commands;
using RentCarApp.Domain.Cities;
using RentCarApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace RentCarApp.Application.Cities.Create
{
    public class CreateCityCommandHandler : ICommandHandler<CreateCityCommand, CityDto>
    {
        private readonly IRepository<City> _cityRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICityUniquenessChecker _cityUniquenessChecker;

        public CreateCityCommandHandler(IRepository<City> cityRepository, ICityUniquenessChecker cityUniquenessChecker, IUnitOfWork unitOfWork)
        {
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
            _cityUniquenessChecker = cityUniquenessChecker;
        }

        public async Task<CityDto> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var newCity = City.CreateCity(request.NameAr, request.NameEn, _cityUniquenessChecker);
            await _cityRepository.AddAsync(newCity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new CityDto
            {
                Id = newCity.Id
            };
        }
    }
}
