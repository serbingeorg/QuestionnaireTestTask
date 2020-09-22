using QuestionnaireTestTask.Models;
using QuestionnareTestTask.ApiContracts.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Repositories.Interfaces
{
    public interface IQuestionnaireRepository : IBaseRepository<Questionnaire>
    {
      
        Task<IEnumerable<Questionnaire>> GetQuestionnairesByPersonId(int userId);
       
    }
}
