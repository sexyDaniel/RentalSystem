﻿using PapsCourse.Server.Interfaces;
using PapsCourse.Shared.DbModels;
using PapsCourse.Shared.Models.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private AppDbContext context;
        public ServiceRepository(AppDbContext context) 
        {
            this.context = context;
        }
        public List<Service> GetServices()
        {
            return context.Services.ToList();
        }
    }
}
