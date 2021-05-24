using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PapsCourse.Server.Interfaces;
using PapsCourse.Shared.Models.Area;
using PapsCourse.Shared.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private ISquareRepository squareRepository;
        public AreaController(ISquareRepository squareRepository) 
        {
            this.squareRepository = squareRepository;
        }

        [HttpGet("getAreas")]
        public List<AreaResponse> GetSquares() 
        {
            return squareRepository.GetAreas();
        }

        [HttpGet("getAreaById/{AreaId}")]
        public AreaResponse GetAreaById(int AreaId)
        {
            return squareRepository.GetAreaById(AreaId);
        }

        [HttpPut("editArea")]
        public IActionResult EditSquare(EditSquareRequest request)
        {
            squareRepository.Update(request);
            return Ok();
        }
    }
}
