using QuestionnaireTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Repositories.Interfaces
{
   public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<IEnumerable<Questionnaire>> GetQuestionnairesByPerson(Person person);
    }
}
