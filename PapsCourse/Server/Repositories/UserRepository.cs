using PapsCourse.Server.Interfaces;
using PapsCourse.Shared.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext context;
        public UserRepository(AppDbContext context) => this.context = context;
        public IQueryable<User> Users => context.Users;

        public void Add(User user)
        {
            var checkUser = context.Users.FirstOrDefault(u => u.Email == user.Email || u.Phone == user.Phone);
            if (checkUser == null)
            {
                context.Add(user);
            }
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var checkUser = context.Users.FirstOrDefault(u => u.Id == id);
            if (checkUser != null)
            {
                context.Users.Remove(checkUser);
            }
            context.SaveChanges();
        }

        public void Update(User user)
        {
            var checkUser = context.Users.FirstOrDefault(u => u.Id == user.Id);
            if (checkUser != null)
            {
                context.Users.Update(user);
            }
            context.SaveChanges();
        }

        public User SearchByEmail(string email)
        {
            return context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetUserById(int userId)
        {
            return context.Users.FirstOrDefault(u=>u.Id==userId);
        }
    }
}
