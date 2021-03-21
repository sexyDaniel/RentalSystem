using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Shared.Account
{
    public class RegistrationRequest
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }        
    }
}
