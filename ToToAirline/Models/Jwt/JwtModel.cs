using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToToAirline.Models.Jwt
{
    public class JwtModel
    {
        public string Token { get; }

        public JwtModel(string token)
        {
            Token = token;
        }
    }
}