using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Shared.Models.Area
{
    public class StatementForRent
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public double AverageReciept { get; set; }
        public int SquareId { get; set; }
        public string Text { get; set; }
        public int AnswerStatementId { get; set; }
    }
}
