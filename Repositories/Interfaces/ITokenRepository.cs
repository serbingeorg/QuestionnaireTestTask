using QuestionnareTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Repositories.Interfaces
{
   public interface ITokenRepository : IBaseRepository<RefreshToken>
    {
        Task<RefreshToken> GetAsync(Expression<Func<RefreshToken, bool>> predicate);
    }
}
