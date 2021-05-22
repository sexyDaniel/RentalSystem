using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PapsCourse.Shared.Models.Area;

namespace PapsCourse.Server.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        void AddCategory(Category category);
    }
}
