using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCarApp.Application.Cities;
using RentCarApp.Application.Cities.Create;
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

        //[HttpPost]
        //[ProducesResponseType(typeof(CityDto), (int)HttpStatusCode.Created)]
        //public async Task<IActionResult> RegisterCustomer([FromBody] CreateCityRequest request)
        //{
        //    var customer = await _mediator.Send(new CreateCityCommand(request.NameAr, request.NameAr));

        //    return Created(string.Empty, customer);
        //}

        [HttpGet]
        public IActionResult Test()
        {
            return Ok("Done");
        }
    }
}
