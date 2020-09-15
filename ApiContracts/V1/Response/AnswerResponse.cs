using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.ApiContracts.Response
{
    public class AnswerResponse
    {
        public int Id { get; set; }
        public string Body { get; set; } 
        public int TimesSelected { get; set; }
    }
}
