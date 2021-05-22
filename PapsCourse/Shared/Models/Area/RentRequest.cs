using System;
using System.Collections.Generic;
using System.Text;

namespace PapsCourse.Shared.Models.Area
{
    public class RentRequest
    {
        public int SquareId { get; set; }
        public int StoreId { get; set; }
        public int CategoryId { get; set; }
        public int AverageReciept { get; set; }
        public string Text { get; set; }        
    }
}
