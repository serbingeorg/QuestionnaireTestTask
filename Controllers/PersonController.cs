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
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll(Person person)
        {
            return Ok(await _personService.GetQuestionnairesByPerson(person));
        }
    }
}
