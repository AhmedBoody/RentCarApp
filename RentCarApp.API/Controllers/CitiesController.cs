using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCarApp.Application.Cities;
using RentCarApp.Application.Cities.Create;
using RentCarApp.Application.Cities.Delete;
using RentCarApp.Application.Cities.List;
using RentCarApp.Application.Cities.Update;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RentCarApp.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class CitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CitiesController(IMediator mediator)
        {
            _mediator  = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CityDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityRequest request)
        {
            var customer = await _mediator.Send(new CreateCityCommand(request.NameAr, request.NameAr));


            return Created(string.Empty, customer);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CityDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCity([FromBody] UpdateCityRequest request)
        {
            var city = await _mediator.Send(new UpdateCityCommand(request.NameAr, request.NameAr,request.Id));

            return Ok(city);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CityDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromQuery] string filter)
        {
            var list = await _mediator.Send(new ListCityQuery(filter));

            return Ok(list);
        }

        [HttpDelete("Delete/{Id}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete([FromRoute] string Id)
        {
             await _mediator.Send(new DeleteCityCommand(Guid.Parse(Id)));

            return Ok("Deleted Successfully");
        }

    }
}
