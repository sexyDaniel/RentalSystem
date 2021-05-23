using Microsoft.EntityFrameworkCore;
using PapsCourse.Server.Interfaces;
using PapsCourse.Shared.Models;
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

        public List<StatementForAddedService> GetAddedStatements()
        {
            throw new NotImplementedException();
        }

        public List<StatementForRent> GetRentStatements()
        {
            return context.StatementForRents
                .Include(s=>s.Store)
                .Include(s=>s.Category)
                .ToList();
        }
    }
}
