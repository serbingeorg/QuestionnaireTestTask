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
     
    }

}
