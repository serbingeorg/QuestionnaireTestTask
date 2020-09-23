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

        public async Task<Answer> GetByIdAsync(int id)
        {
            return await _answerRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(int answerId, AnswerRequest answerRequest)
        {
            Answer existingAnswer = await _answerRepository.GetByIdAsync(answerId);
            if(existingAnswer == null)
            {
                return false;
            }

            existingAnswer.Body = answerRequest.Body;
            return await _answerRepository.UpdateAsync(existingAnswer);
        }
    }
}
