
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToToAirline.BaseResponses;
using ToToAirline.DTOs.Baggage;
using ToToAirline.IService;
using ToToAirline.Models.Baggage;
using ToToAirline.Models.Booking;
using ToToAirline.Models.Passenger;
using ToToAirline.Models.Passenger.Baggage;

namespace ToToAirline.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize]
    public class BaggageController : ControllerBase
    {
        private readonly IBaggageService _baggage;

        public BaggageController(IBaggageService baggage)
        {
            _baggage = baggage;
        }
        [HttpGet("{BookingId}")]
        public IActionResult GetBaggage(Guid BookingId)
        {
            var baggage = _baggage.GetBaggage(BookingId);
            var dto = new GetBaggageResponse(baggage.Id, baggage.WeightInKg
            , new GetBookingResponse(baggage.GetBookings!.Id, baggage.GetBookings.FlightId, baggage.GetBookings.Status, baggage.GetBookings.BookingPaltform, baggage.GetBookings.Passengers
            .Select(p => new GetPassengerResponse(p.Id, p.FirstName, p.LastName, p.DateOfBirthday, p.PassportNumber)).ToList()));

            var response = new BaseResponse<GetBaggageResponse>(status: true, "200", msg: "Succesed", dto);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult CreateBaggage([FromBody] CreateBaggageRequest create)
        {
           _baggage.CreateBaggage(new CreateBaggageDto(create.WeightInKg,create.BookingId));
            var response = new BaseResponse(status: true, "200", msg: "Succesed");
            return Ok(response);
        }
        [HttpDelete("{bookingId}")]
        public IActionResult DeleteBaggage(Guid bookingId)
        { 
            _baggage.DeleteBaggage(bookingId);
           var response =  new BaseResponse(status:true, "200", msg: "Succesed");
            return Ok(response);
        }
        [HttpPut("{baggageId}")]
        public IActionResult UpdateBaggage(Guid baggageId, UpdateBaggageRequest update)
        {
            _baggage.UpdateBaggage(baggageId, new UpdateBaggageDto(update.WeightInKg, update.BookingId));
            var response = new BaseResponse(status:true, "200", msg: "Succesed");
            return Ok(response);
            
        }
    }
}
