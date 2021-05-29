using PapsCourse.Shared.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Interfaces
{
    public interface IAnswerRepository
    {
        void AnswerForRent(AnswerStatementRequest request);
        void AnswerForService(AnswerStatementRequest request);
    }
}
