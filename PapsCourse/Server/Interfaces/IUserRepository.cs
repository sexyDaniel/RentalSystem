﻿using PapsCourse.Shared.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        void Add(User user);
        void Delete(int id);
        void Update(User user);
        User SearchByEmail(string email);
        IQueryable<User> Users { get; }
    }
}
