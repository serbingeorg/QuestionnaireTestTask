using Microsoft.AspNetCore.Mvc;
using QuestionnaireTestTask.Models;
using QuestionnareTestTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QuestionnareTestTask.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
    }
}
