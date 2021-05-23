using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Shared.Models
{
    public class AnswerStatement
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsSuccess { get; set; }
    }
}
