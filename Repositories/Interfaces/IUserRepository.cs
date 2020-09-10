using QuestionnaireTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Repositories.Interfaces
{
   public interface IUserRepository : IBaseRepository<User>
    {
        Task<IEnumerable<Questionnaire>> GetQuestionnairesByPerson(User user);
    }
}
