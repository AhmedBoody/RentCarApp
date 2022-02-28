using MediatR;
using RentCarApp.Application.Cities.Update;
using RentCarApp.Application.Configuration.Commands;
using RentCarApp.Domain.Cities;
using RentCarApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace RentCarApp.Application.Cities.Delete
{
    public class DeleteCityCommandHandler : ICommandHandler<DeleteCityCommand, Unit>
    {
        private readonly IRepository<City> _cityRepository;
        private readonly IUnitOfWork _unitOfWork;


        public DeleteCityCommandHandler(IRepository<City> cityRepository, IUnitOfWork unitOfWork)
        {
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetFirstOrDefaultAsync(r => r.Id == request.CityId);

            if (city == null)
                throw new KeyNotFoundException("no city for this Id");

            await _cityRepository.RemoveAsync(city.Id);
            await _unitOfWork.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
