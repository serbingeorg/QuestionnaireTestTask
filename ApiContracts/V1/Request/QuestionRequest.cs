using QuestionnareTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.ApiContracts.Request
{
    public class QuestionRequest
    {
        public string Body { get; set; }
        public AnswerType Type { get; set; }
        public int QuestionnaireId { get; set; }
    }
}
