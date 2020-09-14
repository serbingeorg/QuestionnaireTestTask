using QuestionnaireTestTask.Models;
using QuestionnareTestTask.ApiContracts.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<QuestionnaireResponse>> GetQuestionnairesByPerson(User user);
    }
}
