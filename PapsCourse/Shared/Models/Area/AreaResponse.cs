using System;
using System.Collections.Generic;
using System.Text;

namespace PapsCourse.Shared.Models.Area
{
    public class AreaResponse
    {
        public int Id { get; set; }
        public double Square { get; set; }
        public bool HasConditioner { get; set; }
        public int EntriesCount { get; set; }
        public int WindowsCount { get; set; }
        public bool HasToilet { get; set; }
        public double Price { get; set; }
        public string PlanImage { get; set; }
    }
}
