using System;
using System.Collections.Generic;
using System.Text;

namespace PapsCourse.Shared.Models.Area
{
    public class ServiceRequest
    {
        public string Text { get; set; }
        public int ServiceId { get; set; }
        public DateTime Date { get; set; }
        public int AreaId { get; set; }
    }
}
