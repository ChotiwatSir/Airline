using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToToAirline.BaseResponses;
using ToToAirline.DTOs.Booking;
using ToToAirline.IService;
using ToToAirline.Models.Booking;
using ToToAirline.Models.Passenger;

namespace ToToAirline.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize]
    public class BookingController:ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet("{passengerId}")]
        public IActionResult GetBooking(Guid passengerId)
        {
            var booking = _bookingService.GetBooking(passengerId);
            var dto = new GetBookingResponse(booking.Id, booking.FlightId, booking.Status, booking.BookingPaltform, booking.Passengers
            .Select(p => new GetPassengerResponse(p.Id, p.FirstName, p.LastName, p.DateOfBirthday, p.PassportNumber)).ToList());

            var response = new BaseResponse<GetBookingResponse>(status: true, "200", msg: "Succesed", dto);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult CreateBooking([FromBody] CreateBookingRequest create)
        {
            _bookingService.CreateBooking(new CreateBookingDto(create.FlightId, create.Status, create.BookingPaltform,create.PassengerId));
            var response = new BaseResponse(status: true, "200", "Succesed");
            return Ok(response);
        }
        [HttpDelete("{bookingId}")]
        public IActionResult DeleteBooking(Guid bookingId)
        { 
            _bookingService.DeleteBooking(bookingId);
            var response = new BaseResponse(status: true, "200",msg: "Succesed");
            return Ok(response);
        }
        [HttpPut("{passengerId}")]
        public IActionResult UpdateBooking(Guid passengerId, UpdateBookingRequest update)
        { 
         _bookingService.UpdateBooking(passengerId, new UpdateBookingDto(update.FlightId,update.Status,update.BookingPaltform,update.PassengerId));
         var response =new BaseResponse(status:true, "200", msg:"Succesed");
            return Ok(response);
        }
    }
}