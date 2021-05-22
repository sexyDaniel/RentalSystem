using PapsCourse.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Models.Repositories
{
    public class StatementRepository : IStatementRepository
    {
        private AppDbContext context;
        public StatementRepository(AppDbContext context) 
        {
            this.context = context;
        }
        public IQueryable<StatementForRent> StatementForRents => context.StatementForRents;

        public IQueryable<StatementForAddedService> StatementForAddedServices => context.StatementForAddedServices;

        public void AddStatementForAddedService(StatementForAddedService statementForAddedService)
        {
            context.StatementForAddedServices.Add(statementForAddedService);
            context.SaveChanges();
        }

        public void AddStatementForRent(StatementForRent statementForRent)
        {
            context.StatementForRents.Add(statementForRent);
            context.SaveChanges();
        }
    }
}
