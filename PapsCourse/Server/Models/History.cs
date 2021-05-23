using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Models
{
    public class History
    {
        public int Id { get; set; }
        public int SquareId { get; set; }
        public Area Square { get; set; }
        public string Action { get; set; }
        public DateTime Date { get; set; }
        public int More { get; set; }
    }
}
