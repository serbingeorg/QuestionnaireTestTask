using AutoMapper;
using QuestionnaireTestTask.Models;
using QuestionnareTestTask.ApiContracts.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Mapping
{
    public class AnswerRequestToAnswerMappingProfile : Profile
    {
        public AnswerRequestToAnswerMappingProfile()
        {
            CreateMap<AnswerRequest, Answer>();
        }
    }
}
