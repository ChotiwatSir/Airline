using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToToAirline.BaseResponses;
using ToToAirline.DTOs.BoardingPass;
using ToToAirline.IService;
using ToToAirline.Models.BoardingPass;
using ToToAirline.Models.Booking;
using ToToAirline.Models.Passenger;

namespace ToToAirline.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize]
    public class BoardingPassController:ControllerBase
    {
        private readonly IBoardingPassService _boardingPassService;

        public BoardingPassController(IBoardingPassService boardingPassService)
        {
            _boardingPassService = boardingPassService;
        }
        [HttpGet("{BookingId}")]
        public IActionResult GetBoardingPass(Guid BookingId)
        {
           var boardingpass =  _boardingPassService.GetBoardingPass(BookingId);
           var dto = new GetBoardingPassResponse(boardingpass.Id, boardingpass.QRCode, new GetBookingResponse(boardingpass.Booking!.Id, boardingpass.Booking.FlightId, boardingpass.Booking.Status, boardingpass.Booking.BookingPaltform, boardingpass.Booking.Passengers
            .Select(p => new GetPassengerResponse(p.Id, p.FirstName, p.LastName, p.DateOfBirthday, p.PassportNumber)).ToList()));

            var response = new BaseResponse<GetBoardingPassResponse>(status: true, "200", msg: "Succesed", dto);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult CreateBoardingPass([FromBody] CreateBoardingPassRequest create,Guid BookingId)
        {
            _boardingPassService.CreateBoardingPass(BookingId, new CreateBoardingPassDto(create.QRCode));
            var response = new BaseResponse(status:true,"200", msg: "Succesed");
            return Ok(response);
        }
    }
}