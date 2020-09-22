using Microsoft.EntityFrameworkCore;
using QuestionnaireTestTask.Models;
using QuestionnareTestTask.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Repositories.Implementations
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(QuestionnaireDBContext questionnaireDBContext) : base(questionnaireDBContext)
        {
            

        }

        public async Task<Question> GetByIdNoTracked(int id)
        {
           return await _questionnaireDBContext.Questions.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

    }
}
