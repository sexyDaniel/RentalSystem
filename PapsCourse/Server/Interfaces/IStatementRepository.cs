using PapsCourse.Server.Models;
using PapsCourse.Shared.Models.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Interfaces
{
    public interface IStatementRepository
    {
        StatementForRent GetRentStatementsByUserId(int userId);
        StatementForAddedService GetAddedStatementsByUserId(int userId);
        List<StatementForRent> GetRentStatements();
        List<TableServiceStatement> GetAddedStatements();
        StatementForRent GetRentStatmentById(int statementID);
        StatementForAddedService GetAddedStatmentById(int statementID);

        void AddStatementForRent(Shared.DbModels.StatementForRent statementForRent);
        void AddStatementForAddedService(Shared.DbModels.StatementForAddedService statementForAddedService);
    }
}
