using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PapsCourse.Server.Interfaces;
using PapsCourse.Server.Models;
using PapsCourse.Shared.Models.Area;
using PapsCourse.Shared.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SquareController : ControllerBase
    {
        private ISquareRepository squareRepository;
        public SquareController(ISquareRepository squareRepository) 
        {
            this.squareRepository = squareRepository;
        }

        [HttpGet("getSquares")]
        public List<Area> GetSquares() 
        {
            return squareRepository.GetAreas();
        }

        [HttpGet("GetAreaById/{AreaId}")]
        public Area GetAreaById(int AreaId)
        {
            return squareRepository.GetAreaById(AreaId);
        }

        [HttpPut("EditSquare")]
        public IActionResult EditSquare(EditSquareRequest request)
        {
            squareRepository.Update(request);
            return Ok();
        }
    }
}
