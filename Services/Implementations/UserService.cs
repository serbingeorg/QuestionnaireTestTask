using AutoMapper;
using QuestionnaireTestTask.Models;
using QuestionnareTestTask.ApiContracts.Response;
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
      public async Task<IEnumerable<QuestionnaireResponse>> GetQuestionnairesByPersonId(int  id)
        {
            IEnumerable<Questionnaire> questionnaires = await _userRepository.GetQuestionnairesByPersonId(id);
            IEnumerable<QuestionnaireResponse> res = _mapper.Map<IEnumerable<Questionnaire>, IEnumerable<QuestionnaireResponse>> (questionnaires);
            return res;
        }
    }
}