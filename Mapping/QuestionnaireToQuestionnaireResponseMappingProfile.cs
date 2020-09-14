﻿using AutoMapper;
using QuestionnaireTestTask.Models;
using QuestionnareTestTask.ApiContracts.Response;
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
