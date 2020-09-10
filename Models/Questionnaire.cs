using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnaireTestTask.Models
{
    public class Questionnaire
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public string URL { get; set; }
        public int UserId { get; set; }
       public virtual Question Question { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public Questionnaire()
        {
            Questions = new HashSet<Question>();
        }

    }
}
