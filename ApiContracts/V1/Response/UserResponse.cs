using QuestionnaireTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.ApiContracts.Response
{
    public class UserResponse
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Questionnaire> Questionnaires { get; set; }
    }
}
