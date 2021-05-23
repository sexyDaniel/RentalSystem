using PapsCourse.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Interfaces
{
    public interface IStoreRepository
    {
        List<Store> GetStores();
        List<Store> GetStoresById(int userId);
        void AddStore(Store store);
        void DeleteStore(int id);
    }
}
