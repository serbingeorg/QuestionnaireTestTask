using QuestionnareTestTask.ApiContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Models.DTO
{
    public class QuestionResponse
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public AnswerType Type { get; set; }
        public List<AnswerResponse> Answers { get; set; }
    }
}
