
using Microsoft.AspNetCore.Mvc;
using ToToAirline.BaseResponses;
using ToToAirline.DTOs.Airport;
using ToToAirline.IService;
using ToToAirline.Models.Passenger.Airport;

namespace ToToAirline.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AirportController:ControllerBase
    {
        private readonly IAirportService _airport;

        public AirportController(IAirportService airport)
        {
            _airport = airport;
        }
        [HttpGet]
        public IActionResult GetAirport()
        {
           var airport = _airport.GetAirport().Select(ap => new GetAirportResponse(ap.Id, ap.AirportName, ap.County, ap.State, ap.City)).ToList();
           var response = new BaseResponse<List<GetAirportResponse>>(status: true, "200", msg: "Succesed", airport!);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult CreateAirport(CreateAirportRequest create)
        {
            _airport.CreateAirport(new CreateAirportDto(create.AirportName, create.County, create.State, create.City));
            var response = new BaseResponse(status: true, "200", msg: "Succesed");
            return Ok(response);
        }
    }
}