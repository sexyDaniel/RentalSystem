using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Models
{
    public class User
    {
        public int Id { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public List<Store> Stores { get; set; } = new List<Store>();
        public List<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
