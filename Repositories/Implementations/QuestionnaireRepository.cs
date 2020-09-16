using Microsoft.EntityFrameworkCore;
using QuestionnaireTestTask.Models;
using QuestionnareTestTask.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Repositories.Implementations
{
    public class QuestionnaireRepository : BaseRepository<Questionnaire>, IQuestionnaireRepository
    {
        public QuestionnaireRepository(QuestionnaireDBContext questionnaireDBContext) : base (questionnaireDBContext)
        {

        }

        public async Task<Questionnaire> GetByIdNoTracked(int id)
        {
           return await _questionnaireDBContext.Questionnaires.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
