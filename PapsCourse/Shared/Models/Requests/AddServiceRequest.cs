using System;
using System.Collections.Generic;
using System.Text;

namespace PapsCourse.Shared.Models.Requests
{
    public class AddServiceRequest
    {
        public int ServiceId { get; set; }
        public int SquareId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}
