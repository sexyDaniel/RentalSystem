using PapsCourse.Server.Interfaces;
using PapsCourse.Shared.DbModels;
using PapsCourse.Shared.Models.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private AppDbContext context;
        public StoreRepository(AppDbContext context) 
        {
            this.context = context;
        }

        public IQueryable<Store> Stores => context.Stores;

        public void AddStore(Store store)
        {
            context.Stores.Add(store);
            context.SaveChanges();
        }

        public void DeleteStore(int id)
        {
            var deleteStore = context.Stores.FirstOrDefault(s => s.Id == id);
            if (deleteStore != null)
            {
                context.Stores.Remove(deleteStore);
                context.SaveChanges();
            }
        }

        public List<StoreResponse> GetStores()
        {
            return context.Stores.Select(s=>new StoreResponse { Id = s.Id,Name =s.Name}).ToList();
        }

        public List<StoreResponse> GetStoresById(int userId)
        {
            return context.Stores
                .Where(s=>s.UserId==userId)
                .Select(s=>new StoreResponse { Id = s.Id,Name = s.Name})
                .ToList();
        }
    }
}
