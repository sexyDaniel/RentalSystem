using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Shared.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StatementForRent> StatementForRents { get; set; } = new List<StatementForRent>();
    }
}
