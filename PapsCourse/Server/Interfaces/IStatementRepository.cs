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
        List<TableRentStatement> GetRentStatementsByUserId(int userId);
        List<TableServiceStatement> GetAddedStatementsByUserId(int userId);
        List<TableRentStatement> GetRentStatements();
        List<TableServiceStatement> GetAddedStatements();
        StatementForRentResponse GetRentStatmentById(int statementID);
        StatementForAddedServiceResponse GetAddedStatmentById(int statementID);

        void AddStatementForRent(Shared.DbModels.StatementForRent statementForRent);
        void AddStatementForAddedService(Shared.DbModels.StatementForAddedService statementForAddedService);
    }
}
