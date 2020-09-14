using AutoMapper;
using QuestionnaireTestTask.Models;
using QuestionnareTestTask.ApiContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Mapping
{
    public class AnswerToAnswerPesponseMappingProfile : Profile
    {
        public AnswerToAnswerPesponseMappingProfile()
        {
            CreateMap<Answer, AnswerResponse>();
        }
    }
}
