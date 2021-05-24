using PapsCourse.Shared.DbModels;
using PapsCourse.Shared.Models.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Interfaces
{
    public interface IStoreRepository
    {
        IQueryable<Shared.DbModels.Store> Stores { get; }
        List<StoreResponse> GetStores();
        List<StoreResponse> GetStoresById(int userId);
        void AddStore(Store store);
        void DeleteStore(int id);
    }
}
