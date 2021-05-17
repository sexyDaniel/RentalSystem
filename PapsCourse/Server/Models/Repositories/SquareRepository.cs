using PapsCourse.Server.Interfaces;
using PapsCourse.Shared.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Models.Repositories
{
    public class SquareRepository : ISquareRepository
    {
        private AppDbContext context;
        public SquareRepository(AppDbContext context) 
        {
            this.context = context;
        }
        public IQueryable<Square> Squares => context.Squares;

        public void Update(EditSquareRequest request)
        {
            var editSquare = context.Squares.FirstOrDefault(s => s.Id == request.Id);
            if (editSquare != null) 
            {
                editSquare.SquarePrice = request.SquarePrice;
                editSquare.SquareValue = request.SquareValue;
                editSquare.WindowsCount = request.WindowsCount;
                editSquare.EntriesCount = request.EntriesCount;
                editSquare.HasContioner = request.HasContioner;
                editSquare.HasToilet = request.HasToilet;
                context.SaveChanges();
            }
        }
    }
}
