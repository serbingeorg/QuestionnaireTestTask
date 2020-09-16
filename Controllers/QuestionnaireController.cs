﻿using Microsoft.AspNetCore.Mvc;
using QuestionnaireTestTask.Models;
using QuestionnareTestTask.ApiContracts.Request;
using QuestionnareTestTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Controllers
{
    [Route("api/[Controller]")]
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

        [HttpGet("api/questionnaires/{questionnaireid}")]  
        public async Task<IActionResult> Get([FromRoute] int questionnaireid)
        {
            Questionnaire questionnaire = await _questionnaireService.GetByIdAsync(questionnaireid);
            if (questionnaire == null)
                return NotFound();
            return Ok(questionnaire);
        }

    }
}
