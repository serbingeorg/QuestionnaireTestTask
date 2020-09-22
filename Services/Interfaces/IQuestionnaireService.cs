using QuestionnaireTestTask.Models;
using QuestionnareTestTask.ApiContracts.Request;
using QuestionnareTestTask.ApiContracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Services.Interfaces
{
   public interface IQuestionnaireService
    {
        Task<bool> CreateAsync(QuestionnaireRequest questionnaireRequest);
        Task<Questionnaire> GetByIdAsync(int id);
        Task<IEnumerable<QuestionnaireResponse>> GetQuestionnairesByPersonId(int id);
        
    }
}
