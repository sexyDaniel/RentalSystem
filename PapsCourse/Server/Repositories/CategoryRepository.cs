﻿using PapsCourse.Server.Interfaces;
using System;
using System.Collections.Generic;
using PapsCourse.Shared.Models.Area;
using System.Linq;

namespace PapsCourse.Server.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDbContext context;
        public CategoryRepository(AppDbContext context) => this.context = context;
        public void AddCategory(Shared.Models.Area.Category category)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            return context.Categories.Select(c=>new Category {Id=c.Id,Name=c.Name }).ToList();
        }
    }
}
