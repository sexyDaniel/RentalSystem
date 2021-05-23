using PapsCourse.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PapsCourse.Shared.Models.Statement
{
    public class RentStatement
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public double AverageReciept { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public string Text { get; set; }
        public int AnswerStatementId { get; set; }
    }
}
