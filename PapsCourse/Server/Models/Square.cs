using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Models
{
    public class Square
    {
        public int Id { get; set; }
        public int StoreId { get; set; } = 0;
        public double SquareValue { get; set; }
        public bool HasContioner { get; set; }
        public int EntriesCount { get; set; }
        public int WindowsCount { get; set; }
        public double SquarePrice { get; set; }
        public bool HasToilet { get; set; }
        public List<StatementForAddedService> StatementForAddedServices { get; set; } = new List<StatementForAddedService>();
        public List<History> Histories { get; set; } = new List<History>();
    }
}
