using Microsoft.AspNetCore.Mvc;
using ToToAirline.BaseResponses;
using ToToAirline.DTOs.BaggageCheck;
using ToToAirline.IService;
using ToToAirline.Models.BaggageCheck;
using ToToAirline.Models.Booking;
using ToToAirline.Models.Passenger;


namespace ToToAirline.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BaggageCheckController:ControllerBase
    {
        private readonly IBaggageCheckService _baggageCheckService;

        public BaggageCheckController(IBaggageCheckService baggageCheckService) 
        {
            _baggageCheckService = baggageCheckService;
        }
        [HttpGet("{BookingId}/{PassengerId}")]
        public IActionResult GetBaggageCheck(Guid BookingId,Guid PassengerId)
        {
           var baggagecheck =  _baggageCheckService.GetBaggageCheck(BookingId, PassengerId);
           var dto = new GetBaggageCheckResponse(baggagecheck.Id, baggagecheck.CheckResult,
                                                 new GetBookingResponse(baggagecheck.GetBookingDto!.Id, baggagecheck.GetBookingDto.FlightId, baggagecheck.GetBookingDto.Status, baggagecheck.GetBookingDto.BookingPaltform
                                                ,baggagecheck.GetBookingDto.Passengers
                                                .Select(p => new GetPassengerResponse(p.Id, p.FirstName, p.LastName, p.DateOfBirthday, p.PassportNumber)).ToList()));
           var response = new BaseResponse<GetBaggageCheckResponse>(status: true, "200", msg: "Succesed", dto);

            return Ok(response);
        }
        [HttpPost]
        public IActionResult CreateBaggageCheck([FromBody] CreateBaggageCheckRequest create)
        {
            _baggageCheckService.CreateBaggageCheck(new CreateBaggageCheckDto(create.CheckResult, create.BookingId, create.PassengerId));
            var response = new BaseResponse(status: true, "200", msg: "Succesed");
            return Ok(response);
        }
        [HttpDelete("{baggageCheckId}")]
        public IActionResult DeleteBaggageCheck(Guid baggageCheckId)
        {
            _baggageCheckService.DeleteBaggageCheck(baggageCheckId);
            var response =  new BaseResponse(status:true, "200", msg: "Succesed");
            return Ok(response);
        }
        [HttpPut("{baggageCheckId}")]
        public IActionResult UpdateBaggageCheck(Guid baggageCheckId,UpdateBaggageCheckRequest update)
        {
            _baggageCheckService.UpdateBaggageCheck(baggageCheckId, new UpdateBaggageCheckDto(update.CheckResult, update.BookingId, update.PassengerId));
            var response = new BaseResponse(status:true, "200", msg: "Succesed");
            return Ok(response);
        }

    }
}