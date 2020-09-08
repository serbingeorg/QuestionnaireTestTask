using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnaireTestTask.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public Questionnaire Questionnaire { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
