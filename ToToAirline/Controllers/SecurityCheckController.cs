using Microsoft.AspNetCore.Mvc;
using ToToAirline.BaseResponses;
using ToToAirline.DTOs.SecurityCheck;
using ToToAirline.IService;
using ToToAirline.Models.Passenger;
using ToToAirline.Models.SecurityCheck;

namespace ToToAirline.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SecurityCheckController : ControllerBase
    {
        private readonly ISecurityCheckService _securityCheckService;

        public SecurityCheckController(ISecurityCheckService securityCheckService)
        {
            _securityCheckService = securityCheckService;
        }
        [HttpGet("{passengerId}")]
        public IActionResult GetSecurityCheck(Guid passengerId)
        {
            var security = _securityCheckService.GetSecurityCheck(passengerId);
            var dto = new GetSecurityCheckResponse(security.Id, security.CheckResult, security.Comment, security.GetPassengers!
            .Select(p => new GetPassengerResponse(p.Id, p.FirstName, p.LastName, p.DateOfBirthday, p.PassportNumber)).ToList());
           var response = new BaseResponse<GetSecurityCheckResponse>(status: true, "200", msg: "Succesed", dto);

            return Ok(response);
        }
        [HttpPost]
        public IActionResult CreateSecurityCheck(CreateSecurityCheckRequest create)
        {
            _securityCheckService.CreateSecurityCheck(new CreateSecurityCheckDto(create.CheckResult, create.Comment,create.PassengerId));
            var response =new BaseResponse(status: true, "200", msg: "Succesed");
            return Ok(response);
        }
    }
}