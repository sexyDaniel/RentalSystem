using PapsCourse.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Interfaces
{
    public interface IStatementRepository
    {
        IQueryable<StatementForRent> StatementForRents { get; }
        IQueryable<StatementForAddedService> StatementForAddedServices { get; }

        void AddStatementForRent(StatementForRent statementForRent);
        void AddStatementForAddedService(StatementForAddedService statementForAddedService);
    }
}
