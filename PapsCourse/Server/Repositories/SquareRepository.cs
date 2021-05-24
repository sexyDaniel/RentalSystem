using PapsCourse.Server.Interfaces;
using PapsCourse.Shared.DbModels;
using PapsCourse.Shared.Models.Requests;
using PapsCourse.Shared.Models.Area;
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

        public AreaResponse GetAreaById(int id)
        {
            var area = context.Areas.FirstOrDefault(s => s.Id == id);
            if (area != null)
                return new AreaResponse
                {
                    Id = area.Id,
                    Square = area.Square,
                    HasConditioner = area.HasConditioner,
                    HasToilet = area.HasToilet,
                    EntriesCount = area.EntriesCount,
                    Price = area.SquarePrice,
                    WindowsCount = area.WindowsCount
                };
            return null;
        }

        public List<AreaResponse> GetAreas()
        {
            return context.Areas.Select(a=>new AreaResponse { 
                Id=a.Id, 
                Square = a.Square,
                HasConditioner = a.HasConditioner,
                HasToilet = a.HasToilet,
                EntriesCount =a.EntriesCount,
                Price = a.SquarePrice,
                WindowsCount = a.WindowsCount
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
                editSquare.HasConditioner = request.HasContioner;
                editSquare.HasToilet = request.HasToilet;
                context.SaveChanges();
            }
        }
    }
}
