using Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boundaries.Persistence
{
    /// <summary>
    /// Represents a contract for a generic repository.
    /// </summary>
    /// <typeparam name="T">The class that represents the db entity.</typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Gets the table of <see cref="T"/> as an <see cref="IQueryable"/>.
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// Retrieves all the elements of <see cref="T"/>.
        /// </summary>
        /// <returns>An instance of <see cref="Task{IList{T}}"/>.</returns>
        Task<IList<T>> GetAllAsync();

        /// <summary>
        /// Retrieves a <see cref="T"/> by its id.
        /// </summary>
        /// <param name="id">The id of the element.</param>
        /// <returns>An instance of <see cref="Task{T}"/>.</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Inserts an element of <see cref="T"/> to the db.
        /// </summary>
        /// <param name="entity">The element of <see cref="T"/> to insert.</param>
        /// <returns>An instance of <see cref="Task"/>.</returns>
        Task InsertAsync(T entity);

        /// <summary>
        /// Updates an element of <see cref="T"/>.
        /// </summary>
        /// <param name="entity">The element of <see cref="T"/> to update.</param>
        /// <returns>An instance of <see cref="Task"/>.</returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Removes an element of <see cref="T"/> from the db.
        /// </summary>
        /// <param name="entity">The element of <see cref="T"/> to remove.</param>
        /// <returns>An instance of <see cref="Task"/>.</returns>
        Task DeleteAsync(T entity);
    }
}
