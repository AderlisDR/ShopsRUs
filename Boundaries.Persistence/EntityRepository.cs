using Boundaries.Persistence.Contexts;
using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boundaries.Persistence
{
    /// <summary>
    /// Represents an implementation for <see cref="IRepository{T}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DefaultContext _context;
        private DbSet<T> _entities;

        /// <summary>
        /// Initializes a new instance of <see cref="EntityRepository"/>.
        /// </summary>
        /// <param name="context">An instance of <see cref="DefaultContext"/>.</param>
        public EntityRepository(
            DefaultContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        ///<inheritdoc/>
        public virtual IQueryable<T> Table => Entities;

        protected virtual DbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());

        ///<inheritdoc/>
        public async Task DeleteAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException("entity");
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        ///<inheritdoc/>
        public async Task<IList<T>> GetAllAsync() => await _entities.ToListAsync();

        ///<inheritdoc/>
        public async Task<T> GetByIdAsync(int id) => await _entities.FirstOrDefaultAsync(e => e.Id == id);

        ///<inheritdoc/>
        public async Task InsertAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException("entity");
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        ///<inheritdoc/>
        public async Task UpdateAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException("entity");
            await _context.SaveChangesAsync();
        }
    }
}
