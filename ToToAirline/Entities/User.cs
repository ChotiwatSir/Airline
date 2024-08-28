using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToToAirline.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public Role Role { get; set; } = null!;
        public Guid RoleId { get; set; }

        public User(Guid id, string name, string password, Guid roleId)
        {
            Id = id;
            Name = name;
            Password = password;
            RoleId = roleId;
        }
    }
}