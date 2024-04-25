using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBIMS_Backend
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string UserLevel { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}