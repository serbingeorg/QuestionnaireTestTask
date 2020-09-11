using QuestionnaireTestTask.Models;
using QuestionnareTestTask.Models.DTO;
using QuestionnareTestTask.Repositories.Interfaces;
using QuestionnareTestTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
      public async Task<IEnumerable<QuestionnaireResponse>> GetQuestionnairesByPerson(User user)
        {
            IEnumerable<Questionnaire> questionnaires = await _userRepository.GetQuestionnairesByPerson(user);
            throw new NotImplementedException();
        }
    }
}