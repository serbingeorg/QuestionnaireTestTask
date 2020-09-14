using AutoMapper;
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
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
      public async Task<IEnumerable<QuestionnaireResponse>> GetQuestionnairesByPerson(User user)
        {
            IEnumerable<Questionnaire> questionnaires = await _userRepository.GetQuestionnairesByPerson(user);
            IEnumerable<QuestionnaireResponse> res = _mapper.Map<IEnumerable<Questionnaire>, IEnumerable<QuestionnaireResponse>> (questionnaires);
            return res;
        }
    }
}