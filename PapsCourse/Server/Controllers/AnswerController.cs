using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PapsCourse.Server.Interfaces;
using PapsCourse.Shared.DbModels;
using PapsCourse.Shared.Models;
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
    public class AnswerController : ControllerBase
    {
        private IAnswerRepository answerRepository;
        public AnswerController(IAnswerRepository answerRepository)
        {
            this.answerRepository = answerRepository;
        }

        [HttpPost("AddAnswerForRent")]
        public void AddAnswerForRent(AnswerStatementRequest request)
        {
            answerRepository.AnswerForRent(request);
        }

        [HttpPost("AddAnswerForService")]
        public void AddAnswerForService(AnswerStatementRequest request)
        {
            answerRepository.AnswerForService(request);
        }

        [HttpGet("getbyid/{id}")]
        public AnswerStatement GetById(int id)
        {
            return answerRepository.GetById(id);
        }
    }
}
