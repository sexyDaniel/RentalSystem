using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PapsCourse.Shared.DbModels;
using PapsCourse.Shared.Models;
using PapsCourse.Shared.Models.Area;

namespace PapsCourse.Server.Interfaces
{
    public interface IServiceRepository
    {
        List<Service> GetServices();
    }
}
