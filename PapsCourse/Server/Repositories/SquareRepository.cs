using PapsCourse.Server.Interfaces;
using PapsCourse.Shared.Models.Area;
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
        public IQueryable<Area> Squares => context.Areas;

        public Shared.Models.Area.Area GetAreaById(int id)
        {
            var square = context.Areas.FirstOrDefault(s => s.Id == id);
            if (square!=null)
                return new Shared.Models.Area.Area {
                    Id=square.Id,
                    Square = square.Square,
                    Price=square.SquarePrice,
                    HasConditioner = square.HasContioner,
                    HasToilet=square.HasToilet,
                    EntriesCount=square.EntriesCount,
                    WindowsCount=square.WindowsCount
                };
            return null;
        }

        public List<Shared.Models.Area.Area> GetAreas()
        {
            return context.Areas
                .Select(s=>new Shared.Models.Area.Area 
                {
                    Id=s.Id,
                    Square = s.Square,
                    Price = s.SquarePrice,
                    HasConditioner = s.HasContioner,
                    HasToilet = s.HasToilet,
                    WindowsCount = s.WindowsCount,
                    EntriesCount = s.EntriesCount
                }).ToList();
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
                editSquare.HasContioner = request.HasContioner;
                editSquare.HasToilet = request.HasToilet;
                context.SaveChanges();
            }
        }
    }
}
