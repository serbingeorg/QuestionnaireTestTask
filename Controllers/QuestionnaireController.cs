using Microsoft.AspNetCore.Mvc;
using QuestionnaireTestTask.Models;
using QuestionnareTestTask.ApiContracts.Request;
using QuestionnareTestTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Controllers
{
    //[Route("api/[Controller]")]
    public class QuestionnaireController : ControllerBase
    {
        private readonly IQuestionnaireService _questionnaireService;
        public QuestionnaireController(IQuestionnaireService questionnaireService)
        {
            _questionnaireService = questionnaireService;
        }

        [HttpPost("api/questionnaire")]

        public async Task<IActionResult> Create( QuestionnaireRequest questionnaireRequest)
        {
            await _questionnaireService.CreateAsync(questionnaireRequest);
            return Created("","");
        }

        [HttpGet("api/questionnaires/{questionnaireid}")]  
        public async Task<IActionResult> Get( int questionnaireid)
        {
            Questionnaire questionnaire = await _questionnaireService.GetByIdAsync(questionnaireid);
            if (questionnaire == null)
                return NotFound();
            return Ok(questionnaire);
        }

        [HttpGet("api/questionnaires/GetAllQuestionnairesByPersonid")]
        public async Task<ActionResult> GetAllQuestionnaires(int id)
        {
            return Ok(await _questionnaireService.GetQuestionnairesByPersonId(id));
        }

        

    }
}
