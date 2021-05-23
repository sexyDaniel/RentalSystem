﻿using PapsCourse.Server.Interfaces;
using PapsCourse.Server.Models;
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

        public List<Store> GetStores()
        {
            return context.Stores.ToList();
        }

        public List<Shared.Models.Area.Store> GetStoresById(int userId)
        {
            return context.Stores.Where(s=>s.UserId==userId).Select(s=>new Shared.Models.Area.Store { 
                Id=s.Id,
                Name = s.Name
            }).ToList();
        }
    }
}