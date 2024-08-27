using Microsoft.AspNetCore.Mvc;
using ToToAirline.BaseResponses;
using ToToAirline.DTOs.FlightManiFest;
using ToToAirline.IService;
using ToToAirline.Models.Booking;
using ToToAirline.Models.Flight;
using ToToAirline.Models.FlightManifest;
using ToToAirline.Models.Passenger;
using ToToAirline.Models.Passenger.Airline;
using ToToAirline.Models.Passenger.Airport;

namespace ToToAirline.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FlightmanifestController : ControllerBase
    {
        private readonly IFlightManiFestService _flightManiFest;

        public FlightmanifestController(IFlightManiFestService flightManiFest)
        {
            _flightManiFest = flightManiFest;
        }
        [HttpGet("{bookingId},{flightId}")]
        public IActionResult GetFlightManifest(Guid bookingId, Guid flightId)
        {
            var flightmanifest = _flightManiFest.GetFlightManiFest(bookingId, flightId);
            var dto = new GetFlightManifestResponse(flightmanifest.BookingId, flightmanifest.FlightId,
            new GetBookingResponse(flightmanifest.BookingDto!.Id, flightmanifest.BookingDto.FlightId, flightmanifest.BookingDto.Status, flightmanifest.BookingDto.BookingPaltform, flightmanifest.BookingDto.Passengers
            .Select(p => new GetPassengerResponse(p.Id, p.FirstName, p.LastName, p.DateOfBirthday, p.PassportNumber)).ToList()
            ), new GetFlightResponse(flightmanifest.FlightDto!.Id, flightmanifest.FlightDto.DepartureGate, flightmanifest.FlightDto.ArrivingGate,flightmanifest.FlightDto.DepartingAirportId, flightmanifest.FlightDto.ArrivingAirportId,
            new GetAirlineResponse(flightmanifest.FlightDto.GetAirline!.Id, flightmanifest.FlightDto.GetAirline.AirlineCode, flightmanifest.FlightDto.GetAirline.AirlineName, flightmanifest.FlightDto.GetAirline.AirlineCounty),
            new GetAirportResponse(flightmanifest.FlightDto.ArrivingAirport.Id, flightmanifest.FlightDto.ArrivingAirport.AirportName, flightmanifest.FlightDto.ArrivingAirport.County, flightmanifest.FlightDto.ArrivingAirport.State, flightmanifest.FlightDto.ArrivingAirport.City),
            new GetAirportResponse(flightmanifest.FlightDto.DepartingAirport.Id, flightmanifest.FlightDto.DepartingAirport.AirportName, flightmanifest.FlightDto.DepartingAirport.County, flightmanifest.FlightDto.DepartingAirport.State, flightmanifest.FlightDto.DepartingAirport.City)));

            var response = new BaseResponse<GetFlightManifestResponse>(status: true, "200", msg: "Succesed", dto);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult CreateFlightManifest(CreateFlightManifestRequest create)
        {
            _flightManiFest.CreateFlightManifest(new CreateFlightManifestDto(create.BookingId, create.FlightId));
            var response = new BaseResponse(status: true, "200", msg: "Succesed");
            return Ok(response);
        }
    }
}