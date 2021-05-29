using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    public class StatementController : ControllerBase
    {
        private IStatementRepository statementRepository;
        public StatementController(IStatementRepository statementRepository) 
        {
            this.statementRepository = statementRepository;
        }

        [HttpGet("GetStatementsForRent")]
        public List<TableRentStatement> GetStatementForRents() 
        {
            return statementRepository.GetRentStatements();
        }

        [HttpGet("GetStatementsForRent/{StatementId}")]
        public StatementForRent GetStatementForRents(int StatementId)
        {
            return statementRepository.GetRentStatmentById(StatementId);
        }

        [HttpGet("GetStatementsForAddedSevice/{StatementId}")]
        public StatementForAddedService GetStatementsForAddedSevice(int StatementId)
        {
            return statementRepository.GetAddedStatmentById(StatementId);
        }

        [HttpGet("GetStatementsForAddedService")]
        public List<TableServiceStatement> GetStatementsForAddedService()
        {
            return statementRepository.GetAddedStatements();
        }

        [HttpPost("addStatementRent")]
        public IActionResult AddStatementForRent(RentRequest request) 
        {
            statementRepository.AddStatementForRent(new Shared.DbModels.StatementForRent { 
                Text=request.Text,
                StoreId=request.StoreId,
                CategoryId = request.CategoryId,
                AverageReciept = request.AverageReciept,
                SquareId = request.SquareId
            });
            return Ok();
        }

        [HttpPost("addStatementAddedService")]
        public IActionResult AddStatementAddedService(AddServiceRequest request)
        {
            statementRepository.AddStatementForAddedService(new Shared.DbModels.StatementForAddedService
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
