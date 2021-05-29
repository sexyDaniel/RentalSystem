using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PapsCourse.Shared.DbModels
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
        public List<StatementForRent> StatementForRent { get; set; } = new List<StatementForRent>();
        public string Logo { get; set; }
    }
}
