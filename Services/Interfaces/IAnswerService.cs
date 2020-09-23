using QuestionnaireTestTask.Models;
using QuestionnareTestTask.ApiContracts.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Services.Interfaces
{
    public interface IAnswerService
    {
        Task<bool> CreateAsync(AnswerRequest answerRequest);
        Task<bool> UpdateAsync(int answerId, AnswerRequest answerRequest);
        Task<Answer> GetByIdAsync(int id);
    }
}
