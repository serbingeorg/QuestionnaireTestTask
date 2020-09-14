using QuestionnaireTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Models.DTO
{
    public class QuestionnaireResponse
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public string URL { get; set; }
    }
}
