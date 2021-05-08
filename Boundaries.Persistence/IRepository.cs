using Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boundaries.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
