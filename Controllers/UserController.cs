using Microsoft.AspNetCore.Mvc;
using QuestionnaireTestTask.Models;
using QuestionnareTestTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QuestionnareTestTask.Controllers
{
    //[ApiController]
    //[Route("api/GetAllQuestionnairesByPersonid")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        //[HttpGet]
        //public async Task<ActionResult> GetAllQuestionnaires( int id)
        //{
        //    return Ok(await _userService.GetQuestionnairesByPersonId(id));
        //}



    }
}
