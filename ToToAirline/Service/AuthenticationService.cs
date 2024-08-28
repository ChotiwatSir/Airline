
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ToToAirline.Entities;
using ToToAirline.IRepository;
using ToToAirline.IService;
using ToToAirline.MiddleWare.Exceptions;

namespace ToToAirline.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _config;
        private readonly IRepository<User> _userRepository;

        public AuthenticationService(IConfiguration config,
                                    IRepository<User> userRepository)
        {
            _config = config;
            _userRepository = userRepository;
        }
        public string Login(string username, string password)
        {
            var user = _userRepository.Table.Where(u => u.Name == username && u.Password == password)
                                                                                             .Select(u => new { userName = u.Name, roleName = u.Role.Name })
                                                                                             .FirstOrDefault();

            if (user == null)
            {

                throw new NotFoundException("User not found");
            }

            var token = GenerateToken(user.userName, user.roleName);

            return token;
        }

        private string GenerateToken(string username, string RoleName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,username),
                new Claim(ClaimTypes.Role,RoleName)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}