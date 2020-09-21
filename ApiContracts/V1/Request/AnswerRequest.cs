using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.ApiContracts.Request
{
    public class AnswerRequest
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int QuestionId { get; set; }
        public int TimesSelected { get; set; }
    }
}
