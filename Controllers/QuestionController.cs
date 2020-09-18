﻿using Microsoft.AspNetCore.Mvc;
using QuestionnareTestTask.ApiContracts.Request;
using QuestionnareTestTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Controllers 
{
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost("api/questions")]
        public async Task<IActionResult> Create ([FromBody] QuestionRequest questionRequest)
        {
            await _questionService.CreateAsync(questionRequest);
            return Created("", "");
        }
        //create question
        //add answer
        //create answer
    }
}
