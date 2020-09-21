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
        //public async Task<IEnumerable<Questionnaire>> GetQuestionnairesByPersonId(int userId)
        //{
        //    //IEnumerable<Questionnaire> questionnaires1 = await _questionnaireDBContext.Users.Include(i => i.Questionnaires).Where(i => i.Id == userId).SelectMany(i=> i.Questionnaires).ToListAsync();
        //    IEnumerable<Questionnaire> res = await _questionnaireDBContext.Questionnaires.Where(i => i.UserId == userId).ToListAsync();
        //    return res;
           
        //}
    }

}
