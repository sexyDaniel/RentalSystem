using System;
using System.Collections.Generic;
using System.Text;

namespace PapsCourse.Shared.Models.Requests
{
    public class AnswerStatementRequest
    {
        public int StatementId { get; set; }        
        public string Text { get; set; }
        public bool IsSuccess { get; set; }
    }
}
