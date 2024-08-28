using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToToAirline.BaseResponses;
using ToToAirline.DTOs.Passenger;
using ToToAirline.IService;
using ToToAirline.Models.Passenger;

namespace ToToAirline.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize]
    public class PassengerController:ControllerBase
    {
        private readonly IPassengerService _passenger;

        public PassengerController(IPassengerService passenger)
        {
            _passenger = passenger;
        }
        [HttpGet]
        public IActionResult GetPassenger()
        {
            var passenger = _passenger.GetPassengers()
                    .Select(p => new GetPassengerResponse(p.Id, p.FirstName, p.LastName, p.DateOfBirthday, p.PassportNumber))
                    .ToList();
            var response = new BaseResponse<List<GetPassengerResponse>>(status: true, "200", "Succesed", passenger);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult CreatePassenger(CreatePassengerRequest request)
        { 
            _passenger.CreatePassenger(new CreatePassengetDto(request.FirstName,request.LastName,request.DateOfBirthday,request.PassportNumber));
            var response = new BaseResponse(status:true, "200", "Succesed");
            return Ok(response);
        }
        [HttpDelete("{passengerId}")]
        public IActionResult DeletePassenger(Guid passengerId)
        {
            _passenger.DeletePassenger(passengerId);
            var response = new BaseResponse(status: true, "200", msg: "Succesed");
            return Ok(response);
        }
        [HttpPut("{passengerId}")]
        public IActionResult UpdatePassenger(Guid passengerId, UpdatePassengerRequest update)
        {
            _passenger.UpdatePassenger(passengerId, new UpdatePassengerDto(update.FirstName, update.LastName, update.DateOfBirthday, update.PassportNumber));
            var response = new BaseResponse(status: true, "200", msg: "Succesed");
            return Ok(response);
        }
    }
}