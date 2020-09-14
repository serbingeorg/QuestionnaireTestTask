using AutoMapper;
using QuestionnaireTestTask.Models;
using QuestionnareTestTask.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Mapping
{
    public class QuestionnaireToQuestionnaireResponseMappingProfile : Profile
    {
        public QuestionnaireToQuestionnaireResponseMappingProfile()
        {
            CreateMap<Questionnaire, QuestionnaireResponse>();
        }
    }
}
