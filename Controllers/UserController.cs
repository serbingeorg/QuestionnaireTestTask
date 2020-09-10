using Microsoft.AspNetCore.Mvc;
using QuestionnaireTestTask.Models;
using QuestionnareTestTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QuestionnareTestTask.Controllers
{
    [ApiController]
    [Route("GetAllQuestionnaires")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllQuestionnaires(User user)
        {
            return Ok(await _userService.GetQuestionnairesByPerson(user));
        }


    }
}
