using PapsCourse.Server.Interfaces;
using PapsCourse.Shared.Models;
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

        public Area GetAreaById(int id)
        {
            var square = context.Areas.FirstOrDefault(s => s.Id == id);
            if (square != null)
                return square;
            return null;
        }

        public List<Area> GetAreas()
        {
            return context.Areas.ToList();
        }

        public void Update(EditSquareRequest request)
        {
            var editSquare = context.Areas.FirstOrDefault(s => s.Id == request.Id);
            if (editSquare != null) 
            {
                editSquare.SquarePrice = request.SquarePrice;
                editSquare.Square = request.SquareValue;
                editSquare.WindowsCount = request.WindowsCount;
                editSquare.EntriesCount = request.EntriesCount;
                editSquare.HasConditioner = request.HasContioner;
                editSquare.HasToilet = request.HasToilet;
                context.SaveChanges();
            }
        }
    }
}
