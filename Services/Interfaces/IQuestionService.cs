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
    }
}
