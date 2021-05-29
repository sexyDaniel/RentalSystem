using System;
using System.Collections.Generic;
using System.Text;

namespace PapsCourse.Shared.Models.Area
{
    public class TableRentStatement
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool? IsSuccessful { get; set; }
        public string Store { get; set; }
        public int AreaId { get; set; }
    }
}
