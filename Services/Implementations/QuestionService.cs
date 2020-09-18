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
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        public QuestionService(IMapper mapper, IQuestionRepository questionRepository)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
        }

        public async Task<bool> CreateAsync(QuestionRequest questionRequest)
        {
            Question question = _mapper.Map<QuestionRequest, Question>(questionRequest);
            return await _questionRepository.AddAsync(question);
        }
    }
}
