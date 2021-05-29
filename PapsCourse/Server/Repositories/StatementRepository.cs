using Microsoft.EntityFrameworkCore;
using PapsCourse.Server.Interfaces;
using PapsCourse.Shared.Models.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Models.Repositories
{
    public class StatementRepository : IStatementRepository
    {
        delegate bool Operation(object c);
        private AppDbContext context;
        public StatementRepository(AppDbContext context) 
        {
            this.context = context;
        }

        public void AddStatementForAddedService(Shared.DbModels.StatementForAddedService statementForAddedService)
        {
            context.StatementForAddedServices.Add(statementForAddedService);
            context.SaveChanges();
        }

        public void AddStatementForRent(Shared.DbModels.StatementForRent statementForRent)
        {
            context.StatementForRents.Add(statementForRent);
            context.SaveChanges();
        }

        public List<TableServiceStatement> GetAddedStatements()
        {
            return context.StatementForAddedServices
                .Join(context.Areas, s => s.SquareId, a => a.Id, (s, a) => new { Statement = s, AreaId = a.Id, StoreId = a.StoreId })
                .Join(context.Stores, id => id.StoreId, s => s.Id, (id, s) => new { StoreName = s.Name, lastJoin = id })
                .Select(join => new TableServiceStatement
                {
                    Id = join.lastJoin.Statement.Id,
                    Date = join.lastJoin.Statement.Date,
                    Store = join.StoreName,
                    IsSuccessful = join.lastJoin.Statement.AnswerStatementId != 0,
                    AreaId = join.lastJoin.AreaId,
                    Category = context.Services
                               .FirstOrDefault(s => s.Id == join.lastJoin.Statement.ServiceId).Name
                }).ToList();
        }

        public StatementForAddedService GetAddedStatementsByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public StatementForAddedService GetAddedStatmentById(int statementID)
        {
            return GetAddedStatementByOrder((s) => (s as Shared.DbModels.StatementForAddedService).Id == statementID);
        }

        public StatementForRent GetRentStatementsByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public StatementForRent GetRentStatmentById(int statementID)
        {
            return GetRentStatementByOrder((s) => (s as Shared.DbModels.StatementForRent).Id == statementID);
        }

        public List<StatementForRent> GetRentStatements()
        {
            return context.StatementForRents
                .Select(statement => new StatementForRent
                {
                    Id = statement.Id,
                    SquareId = statement.SquareId,
                    CategoryId = statement.CategoryId,
                    Category = context.Categories
                            .Where(c => c.Id == statement.CategoryId)
                            .Select(c => new CategoryResponse { Id = c.Id, Name = c.Name })
                            .FirstOrDefault(c => c.Id == statement.CategoryId),
                    StoreId = statement.StoreId,
                    Store = context.Stores
                            .Where(m => m.Id == statement.StoreId)
                            .Select(m => new StoreResponse { Id = m.Id, Name = m.Name })
                            .FirstOrDefault(m => m.Id == statement.StoreId),
                    AnswerStatementId = statement.AnswerStatementId,
                    AverageReciept = statement.AverageReciept,
                    Date = statement.Date,
                    Text = statement.Text
                }).ToList();
        }

        private StatementForRent GetRentStatementByOrder(Operation expression) 
        {
            var statement = context.StatementForRents.ToList().FirstOrDefault(s => expression(s));
            if (statement != null)
            {
                return new StatementForRent
                {
                    Id = statement.Id,
                    SquareId = statement.SquareId,
                    CategoryId = statement.CategoryId,
                    Category = context.Categories
                            .Where(c => c.Id == statement.CategoryId)
                            .Select(c => new CategoryResponse { Id = c.Id, Name = c.Name })
                            .FirstOrDefault(c => c.Id == statement.CategoryId),
                    StoreId = statement.StoreId,
                    Store = context.Stores
                            .Where(m => m.Id == statement.StoreId)
                            .Select(m => new StoreResponse { Id = m.Id, Name = m.Name })
                            .FirstOrDefault(m => m.Id == statement.StoreId),
                    AnswerStatementId = statement.AnswerStatementId,
                    AverageReciept = statement.AverageReciept,
                    Date = statement.Date,
                    Text = statement.Text
                };
            }
            return null;
        }

        private StatementForAddedService GetAddedStatementByOrder(Operation expression)
        {
            var statement = context.StatementForAddedServices.ToList().FirstOrDefault(s => expression(s));
            if (statement != null)
            {
                return ConvertToAddedStatement(statement);
            }
            return null;
        }

        private StatementForAddedService ConvertToAddedStatement(Shared.DbModels.StatementForAddedService statement)
        {
            return new StatementForAddedService
            {
                Id = statement.Id,
                ServiceId = statement.ServiceId,
                Service = context.Services
                            .Where(s => s.Id == statement.ServiceId)
                            .Select(s => new Service { Id = s.Id, Name = s.Name })
                            .FirstOrDefault(s => s.Id == statement.ServiceId),
                Area = null,
                AreaId = statement.SquareId,
                AnswerStatementId = statement.AnswerStatementId,
                Date = statement.Date,
                Text = statement.Text
            };
        }
    }
}
