using System;
using System.Collections.Generic;
using System.Text;

namespace PapsCourse.Shared.Models.Requests
{
    public class StoreRequest
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
        public string Phone { get; set; }
        public string Logo { get; set; }
    }
}
