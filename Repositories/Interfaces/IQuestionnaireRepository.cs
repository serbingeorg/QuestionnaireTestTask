using QuestionnaireTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Repositories.Interfaces
{
    public interface IQuestionnaireRepository : IBaseRepository<Questionnaire>
    {
        //Task<Questionnaire> GetByIdNoTracked(int id);
    }
}
