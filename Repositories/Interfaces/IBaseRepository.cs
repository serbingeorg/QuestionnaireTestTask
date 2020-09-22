using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Repositories.Interfaces
{
    public interface IBaseRepository <T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(T entity);

    }
}
