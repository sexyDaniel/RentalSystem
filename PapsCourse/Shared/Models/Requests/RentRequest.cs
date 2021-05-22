using System;
using System.Collections.Generic;
using System.Text;

namespace PapsCourse.Shared.Models.Requests
{
    public class RentRequest
    {
        public int StoreId { get; set; }
        public int SquareId { get; set; }
        public int CategoryId { get; set; }
        public double AverageReciept { get; set; }
        public string Text { get; set; }
    }
}
