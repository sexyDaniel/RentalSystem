using System;
using System.ComponentModel.DataAnnotations;

namespace PapsCourse.Server.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        [MaxLength(11)]
        public string Phone { get; set; }
        public StatementForRent StatementForRent { get; set; }
    }
}
