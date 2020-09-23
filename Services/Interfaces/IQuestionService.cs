using QuestionnaireTestTask.Models;
using QuestionnareTestTask.ApiContracts.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<bool> CreateAsync(QuestionRequest questionRequest);
        Task<bool> UpdateAsync(int questionId, QuestionRequest questionRequest);
        Task<Question> GetByIdAsync(int id);
        Task<bool> DeleteByIdAsync(int id);


    }
}
