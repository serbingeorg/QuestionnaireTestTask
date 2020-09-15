using Microsoft.AspNetCore.Mvc;
using QuestionnareTestTask.ApiContracts.Request;
using QuestionnareTestTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Controllers
{
    public class QuestionnaireController : ControllerBase
    {
        private readonly IQuestionnaireService _questionnaireService;
        public QuestionnaireController(IQuestionnaireService questionnaireService)
        {
            _questionnaireService = questionnaireService;
        }

        [HttpPost("api/questionnaires")]

        public async Task<IActionResult> Create([FromBody] QuestionnaireRequest questionnaireRequest)
        {
            await _questionnaireService.CreateAsync(questionnaireRequest);
            return Created("","");
        }

    }
}
