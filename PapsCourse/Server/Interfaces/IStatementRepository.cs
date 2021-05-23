using PapsCourse.Server.Models;
using PapsCourse.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Interfaces
{
    public interface IStatementRepository
    {
        List<StatementForRent> GetRentStatements();
        List<StatementForAddedService> GetAddedStatements();

        void AddStatementForRent(StatementForRent statementForRent);
        void AddStatementForAddedService(StatementForAddedService statementForAddedService);
    }
}
