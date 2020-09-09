using QuestionnaireTestTask.Models;
using QuestionnareTestTask.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Repositories.Implementations
{
    public class BaseRepository<T>:IBaseRepository<T> where T : class
    {
        protected readonly QuestionnaireDBContext _questionnaireDBContext;

        public BaseRepository(QuestionnaireDBContext questionnaireDBContext)
        {
            _questionnaireDBContext = questionnaireDBContext;
        }
    }
}
