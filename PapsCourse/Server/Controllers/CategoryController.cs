using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PapsCourse.Server.Interfaces;
using PapsCourse.Shared.Models.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository repository;
        public CategoryController(ICategoryRepository repository) 
        {
            this.repository = repository;
        }

        [HttpGet("getCategories")]
        public List<Category> GetCategories() 
        {
            return repository.GetCategories();
        }
    }
}
