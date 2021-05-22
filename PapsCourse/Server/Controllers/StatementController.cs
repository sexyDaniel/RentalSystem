using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PapsCourse.Server.Interfaces;
using PapsCourse.Server.Models;
using PapsCourse.Shared.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatementController : ControllerBase
    {
        private IStatementRepository statementRepository;
        public StatementController(IStatementRepository statementRepository) 
        {
            this.statementRepository = statementRepository;
        }

        [HttpGet("GetStatementsForRent")]
        public List<StatementForRent> GetStatementForRents() 
        {
            return statementRepository.StatementForRents.ToList();
        }

        [HttpGet("GetStatementsForAddedService")]
        public List<StatementForAddedService> GetStatementForAddedService()
        {
            return statementRepository.StatementForAddedServices.ToList();
        }

        [HttpPost("AddStatementRent")]
        public IActionResult AddStatementForRent(RentRequest request) 
        {
            statementRepository.AddStatementForRent(new StatementForRent { 
                Text=request.Text,
                StoreId=request.StoreId,
                CategoryId = request.CategoryId,
                AverageReciept = request.AverageReciept,
                SquareId = request.SquareId
            });
            return Ok();
        }

        [HttpPost("AddStatementAddedService")]
        public IActionResult AddStatementAddedService(AddServiceRequest request)
        {
            statementRepository.AddStatementForAddedService(new StatementForAddedService
            {
                Text = request.Text,
                SquareId = request.SquareId,
                Date = request.Date,
                ServiceId = request.ServiceId
            });
            return Ok();
        }
    }
}
