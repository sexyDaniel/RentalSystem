using PapsCourse.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        void Delete(int id);
        void Update(User user);
        User SearchByEmail(string email);
        IQueryable<User> Users { get; }
    }
}
