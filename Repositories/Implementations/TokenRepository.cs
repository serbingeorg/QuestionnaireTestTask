using Microsoft.EntityFrameworkCore;
using QuestionnaireTestTask.Models;
using QuestionnareTestTask.Models;
using QuestionnareTestTask.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Repositories.Implementations
{
    public class TokenRepository : BaseRepository<RefreshToken>, ITokenRepository
    {
        public TokenRepository(QuestionnaireDBContext questionnaireDBContext) : base (questionnaireDBContext)
        {

        }

        public async Task<RefreshToken> GetAsync(Expression<Func<RefreshToken, bool>> predicate)
        {
           return await _questionnaireDBContext.RefreshTokens.FirstOrDefaultAsync(predicate);
        }
    }
}
