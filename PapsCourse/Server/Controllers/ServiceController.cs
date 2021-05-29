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
    public class ServiceController : ControllerBase
    {
        private IServiceRepository repository;
        public ServiceController(IServiceRepository repository) 
        {
            this.repository = repository;
        }

        [HttpGet("GetServices")]
        public List<Service> GetServices() 
        {
            return repository.GetServices();
        }
    }
}
