using Microsoft.AspNetCore.Mvc;
using QuestionnareTestTask.ApiContracts.Request;
using QuestionnareTestTask.Repositories.Interfaces;
using QuestionnareTestTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Controllers
{
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpPost("api/answer")]
        public async Task<IActionResult> Create (AnswerRequest answerRequest)
        {
            await _answerService.CreateAsync(answerRequest);
            return Created("", "");
        }
    }
}
