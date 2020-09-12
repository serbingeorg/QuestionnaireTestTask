using Microsoft.EntityFrameworkCore;
using QuestionnaireTestTask.Models;
using QuestionnareTestTask.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository (QuestionnaireDBContext questionnaireDBContext) : base(questionnaireDBContext)
        { }
        public async Task<IEnumerable<Questionnaire>> GetQuestionnairesByPerson(User user)
        {
            //var res = await _questionnaireDBContext.Users.Include(i => i.Questionnaires).FirstOrDefaultAsync(i => i.Id == user.Id);
            //return (IEnumerable<Questionnaire>)res.Questionnaires.Select(i => i.Question);
            return null;
        }
    }

}
//.ThenInclude(i => i.Question)