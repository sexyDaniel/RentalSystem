using PapsCourse.Server.Interfaces;
using PapsCourse.Shared.DbModels;
using PapsCourse.Shared.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private AppDbContext context;
        public AnswerRepository(AppDbContext context) 
        {
            this.context = context;
        }
        public void AnswerForRent(AnswerStatementRequest request)
        {
            var statement = context.StatementForRents.FirstOrDefault(s => s.Id == request.StatementId);
            if (statement != null) 
            {
                var answer = new AnswerStatement { Text = request.Text, IsSuccess = request.IsSuccess };
                context.AnswerStatements.Add(answer);                
                var area = context.Areas.First(a => a.Id == statement.SquareId);
                area.StoreId = statement.StoreId;
                context.SaveChanges();
                statement.AnswerStatementId = answer.Id;
                context.SaveChanges();
            }
        }

        public void AnswerForService(AnswerStatementRequest request)
        {
            var statement = context.StatementForAddedServices.FirstOrDefault(s => s.Id == request.StatementId);
            if (statement != null)
            {
                var answer = new AnswerStatement { Text = request.Text, IsSuccess = request.IsSuccess };
                context.AnswerStatements.Add(answer);
                context.SaveChanges();
                statement.AnswerStatementId = answer.Id;
                context.SaveChanges(); ;
            }
        }

        public AnswerStatement GetById(int id)
        {
            var answer = context.AnswerStatements.FirstOrDefault(a => a.Id == id);
            return new AnswerStatement()
            {
                Id = answer.Id,
                IsSuccess = answer.IsSuccess,
                Text = answer.Text
            };
        }
    }
}
