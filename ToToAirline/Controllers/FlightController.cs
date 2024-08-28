using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToToAirline.BaseResponses;
using ToToAirline.DTOs.Flight;
using ToToAirline.IService;
using ToToAirline.Models.Flight;
using ToToAirline.Models.Passenger.Airline;
using ToToAirline.Models.Passenger.Airport;

namespace ToToAirline.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }
        [HttpGet]
        public IActionResult GetFlight()
        {
            var flight = _flightService.GetFlights().Select(f => new GetFlightResponse(f.Id, f.DepartureGate, f.ArrivingGate,f.DepartingAirportId, f.ArrivingAirportId,
            new GetAirlineResponse(f.GetAirline!.Id, f.GetAirline.AirlineCode, f.GetAirline.AirlineName, f.GetAirline.AirlineCounty),
            new GetAirportResponse(f.ArrivingAirport.Id, f.ArrivingAirport.AirportName, f.ArrivingAirport.County, f.ArrivingAirport.State, f.ArrivingAirport.City),
            new GetAirportResponse(f.DepartingAirport.Id, f.DepartingAirport.AirportName, f.DepartingAirport.County, f.DepartingAirport.State, f.DepartingAirport.City)))
            .ToList();

            var response = new BaseResponse<List<GetFlightResponse>>(status: true, "200", msg: "Succesed", flight);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult CreateFlight([FromBody] CreateFlightRequest create)
        {
            _flightService.CreateFlight(new CreateFlightDto(create.DepartureGate, create.ArrivingGate, create.AirlineId, create.DepartureAirportId, create.ArrivingAirportId));
            var response = new BaseResponse(status: true, "200", msg: "Succesed");
            return Ok(response);
        }
        [HttpDelete("{flightId}")]
        public IActionResult DeleteFlight(Guid flightId)
        {
            _flightService.DeleteFlight(flightId);
            var response = new BaseResponse(status: true, "200", msg: "Succesed");
            return Ok(response);
        }
        [HttpPut("{flightId}")]
        public IActionResult UpdateFlight(Guid flightId, UpdateFlightRequest update)
        {
            _flightService.UpdateFlight(flightId, new UpdateFlightDto(update.DepartureGate, update.ArrivingGate, update.AirlineId, update.DepartureAirportId, update.ArrivingAirportId));
            var response = new BaseResponse(status: true, "200", msg: "Succesed");
            return Ok(response);
        }
    }
}