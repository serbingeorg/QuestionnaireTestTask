using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnaireTestTask.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int QuestionId { get; set; }
        public int TimesSelected { get; set; }
        public virtual Question Question { get; set; }
    }
}
