using PapsCourse.Server.Interfaces;
using PapsCourse.Shared.DbModels;
using PapsCourse.Shared.Models.Requests;
using PapsCourse.Shared.Models.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
                    WindowsCount = area.WindowsCount,
                    PlanImage = area.PlanImage
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
                WindowsCount = a.WindowsCount,
                PlanImage = a.PlanImage
            }).ToList();
        }

        public List<UserArea> GetAreasByUserId(int userId)
        {
            return context.Areas                
                .Join(context.Stores,a=>a.StoreId,s=>s.Id,(a,s)=>new {Id = a.Id, Store = s.Name, UserId = s.UserId })
                .Where(join=>join.UserId == userId)
                .Select(r=>new UserArea() { 
                    Id = r.Id,
                    Store = r.Store                    
                }).ToList();
        }

        public void Update(AreaResponse request)
        {
            var editSquare = context.Areas.FirstOrDefault(s => s.Id == request.Id);
            if (editSquare != null) 
            {
                editSquare.SquarePrice = request.Price;
                editSquare.Square = request.Square;
                editSquare.WindowsCount = request.WindowsCount;
                editSquare.EntriesCount = request.EntriesCount;
                editSquare.HasConditioner = request.HasConditioner;
                editSquare.HasToilet = request.HasToilet;
                editSquare.PlanImage = request.PlanImage;
                context.SaveChanges();
            }
        }
    }
}
