using System;
using System.Collections.Generic;
using System.Text;

namespace PapsCourse.Shared.Models.Account
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
