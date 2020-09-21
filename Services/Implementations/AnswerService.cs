using AutoMapper;
using QuestionnaireTestTask.Models;
using QuestionnareTestTask.ApiContracts.Request;
using QuestionnareTestTask.Repositories.Interfaces;
using QuestionnareTestTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Services.Implementations
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;
        public AnswerService(IMapper mapper, IAnswerRepository answerRepository)
        {
            _mapper = mapper;
            _answerRepository = answerRepository;
        }

        public async Task<bool> CreateAsync(AnswerRequest answerRequest)
        {
            Answer answer = _mapper.Map<AnswerRequest, Answer>(answerRequest);
            return await _answerRepository.AddAsync(answer);
        }
    }
}
