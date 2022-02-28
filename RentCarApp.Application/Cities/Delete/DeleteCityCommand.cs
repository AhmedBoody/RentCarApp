using MediatR;
using RentCarApp.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Application.Cities.Delete
{
    public class DeleteCityCommand : CommandBase<Unit>
    {
        public Guid CityId { get; }
        public DeleteCityCommand(Guid cityId)
        {
            this.CityId = cityId;
        }
    }
}
