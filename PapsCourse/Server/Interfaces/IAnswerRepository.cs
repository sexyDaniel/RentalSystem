using PapsCourse.Shared.Models.Area;
using PapsCourse.Shared.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PapsCourse.Shared.Models.Requests;

namespace PapsCourse.Server.Interfaces
{
    public interface IAnswerRepository
    {
        void AnswerForRent(AnswerStatementRequest request);
        void AnswerForService(AnswerStatementRequest request);
        AnswerStatement GetById(int id);
    }
}
