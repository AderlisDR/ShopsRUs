using Boundaries.Persistence.Contexts;
using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boundaries.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DefaultContext _context;
        private DbSet<T> _entities;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public EntityRepository(
            DefaultContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException("entity");
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<T>> GetAllAsync() => await _entities.ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _entities.FirstOrDefaultAsync(e => e.Id == id);

        public async Task InsertAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException("entity");
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException("entity");
            await _context.SaveChangesAsync();
        }
    }
}
