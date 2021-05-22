using PapsCourse.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Interfaces
{
    public interface IStoreRepository
    {
        IQueryable<Store> Stores { get; }
        void AddStore(Store store);
        void DeleteStore(int id);
    }
}
