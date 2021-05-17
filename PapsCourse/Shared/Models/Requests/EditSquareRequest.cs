using System;
using System.Collections.Generic;
using System.Text;

namespace PapsCourse.Shared.Models.Requests
{
    public class EditSquareRequest
    {
        public int Id { get; set; }
        public double SquareValue { get; set; }
        public bool HasContioner { get; set; }
        public int EntriesCount { get; set; }
        public int WindowsCount { get; set; }
        public double SquarePrice { get; set; }
        public bool HasToilet { get; set; }
    }
}
