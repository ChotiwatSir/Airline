using Microsoft.AspNetCore.Mvc;
using ToToAirline.BaseResponses;
using ToToAirline.DTOs.Airline;
using ToToAirline.IService;
using ToToAirline.Models.Passenger.Airline;

namespace ToToAirline.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AirlineController:ControllerBase
    {
        private readonly IAirlineService _airline;

        public AirlineController(IAirlineService airline)
        {
            _airline = airline;
        }
        [HttpGet]
        public IActionResult GetAirline()
        {
            var airline = _airline.GetAirline().Select(a => new GetAirlineResponse(a.Id, a.AirlineCode, a.AirlineName, a.AirlineCounty)).ToList();
            var response = new BaseResponse<List<GetAirlineResponse>>(status: true, "200", msg: "Succesed", airline!);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult CreateAirline(CreateAirlineRequest create)
        {
            _airline.CreateAirline(new CreateAirlineDto(create.AirlineCode, create.AirlineName, create.AirlineCounty));
            var response = new BaseResponse(status: true, "200", msg: "Succesed");
            return Ok(response);    
        }
    }
}