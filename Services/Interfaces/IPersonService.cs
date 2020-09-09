using QuestionnaireTestTask.Models;
using QuestionnareTestTask.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Services.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<QuestionnaireResponse>> GetQuestionnairesByPerson(Person person);
    }
}
