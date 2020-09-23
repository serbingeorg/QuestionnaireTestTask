using AutoMapper;
using QuestionnaireTestTask.Models;
using QuestionnareTestTask.ApiContracts;
using QuestionnareTestTask.ApiContracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Mapping
{
    public class UserToUserResponseMappingProfile : Profile
    {
        public UserToUserResponseMappingProfile()
        {
           CreateMap<User, UserResponse>();
        }
    }
}
