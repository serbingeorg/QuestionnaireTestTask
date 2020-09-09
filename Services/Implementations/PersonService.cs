using QuestionnaireTestTask.Models;
using QuestionnareTestTask.Models.DTO;
using QuestionnareTestTask.Repositories.Interfaces;
using QuestionnareTestTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
      public async Task<IEnumerable<QuestionnaireResponse>> GetQuestionnairesByPerson(Person person)
        {
            IEnumerable<Questionnaire> questionnaires = await _personRepository.GetQuestionnairesByPerson(person);
            throw new NotImplementedException();
        }
    }
}
