using AutoMapper;
using QuestionnaireTestTask.Models;
using QuestionnareTestTask.ApiContracts.Request;
using QuestionnareTestTask.ApiContracts.Response;
using QuestionnareTestTask.Repositories.Interfaces;
using QuestionnareTestTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Services.Implementations
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly IQuestionnaireRepository _questionnaireRepository;
        private readonly IMapper _mapper;

        public QuestionnaireService(IMapper mapper, IQuestionnaireRepository questionnaireRepository)
        {
            _mapper = mapper;
            _questionnaireRepository = questionnaireRepository;
        }

        public async Task<bool> CreateAsync(QuestionnaireRequest questionnaireRequest)
        {
            Questionnaire questionnaire = _mapper.Map<QuestionnaireRequest, Questionnaire>(questionnaireRequest);
            return await _questionnaireRepository.AddAsync(questionnaire);
        }

        public async Task<Questionnaire> GetByIdAsync(int id)
        {
           return await _questionnaireRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<QuestionnaireResponse>> GetQuestionnairesByPersonId(int id)
        {
            IEnumerable<Questionnaire> questionnaires = await _questionnaireRepository.GetQuestionnairesByPersonId(id);
            IEnumerable<QuestionnaireResponse> res = _mapper.Map<IEnumerable<Questionnaire>, IEnumerable<QuestionnaireResponse>>(questionnaires);
            return res;
        }
    }
}
