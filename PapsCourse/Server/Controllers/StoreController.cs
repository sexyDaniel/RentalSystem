using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PapsCourse.Server.Interfaces;
using PapsCourse.Server.Models;
using PapsCourse.Shared.Models;
using PapsCourse.Shared.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private IStoreRepository storeRepository;
        public StoreController(IStoreRepository storeRepository) 
        {
            this.storeRepository = storeRepository;
        }

        [HttpGet("getStores/{userId}")]
        public List<Shared.Models.Area.Store> GetStoresById(int userId) 
        {
            return storeRepository.GetStoresById(userId);
        }

        [HttpPost("addStore")]
        public Response AddStore(StoreRequest request) 
        {
            var response = new Response() { Errors = new List<string>()};
            if (UniqueStoreName(request)) 
            {
                if (UniqueStorePhone(request))
                {
                    storeRepository.AddStore(new Store
                    {
                        UserId = request.UserId,
                        StartTime = request.StartTime,
                        EndTime = request.FinishTime,
                        Phone = request.Phone,
                        Name = request.Name
                    });
                }
                else 
                {
                    response.Errors.Add("Такой номер телефона уже есть");
                }
            }
            else
            {
                response.Errors.Add("Такой магазин уже есть");
            }
            return response;
        }

        [HttpPost("DeleteStore")]
        public IActionResult DeleteStore(int id)
        {
            storeRepository.DeleteStore(id);
            return Ok();
        }

        private bool UniqueStoreName(StoreRequest request) =>
            storeRepository.GetStores().FirstOrDefault(s => s.Name == request.Name) == null;


        private bool UniqueStorePhone(StoreRequest request) =>
            storeRepository.GetStores().FirstOrDefault(s => s.Phone == request.Phone) == null;
    }
}
