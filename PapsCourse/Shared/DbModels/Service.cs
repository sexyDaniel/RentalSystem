using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Shared.DbModels
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StatementForAddedService> StatementForAddedServices { get; set; } = new List<StatementForAddedService>();
    }
}
