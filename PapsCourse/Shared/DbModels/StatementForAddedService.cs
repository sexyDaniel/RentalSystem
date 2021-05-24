using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Shared.DbModels
{
    public class StatementForAddedService
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int SquareId { get; set; }
        public Area Square { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public int AnswerStatementId { get; set; }
    }
}
