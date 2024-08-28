
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToToAirline.IService;
using ToToAirline.Models.Jwt;
using ToToAirline.Models.Login;

namespace ToToAirline.Controllers
{
    [AllowAnonymous]
    [Route("[Controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {

            var token = _authenticationService.Login(request.Username, request.Password);

            var res = new JwtModel(token);

            return Ok(res);
        }

    }
}