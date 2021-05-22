using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<AnswerStatement> AnswerStatements { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Square> Squares { get; set; }
        public DbSet<StatementForAddedService> StatementForAddedServices { get; set; }
        public DbSet<StatementForRent> StatementForRents { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
