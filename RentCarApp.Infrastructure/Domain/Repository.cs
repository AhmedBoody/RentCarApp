using Microsoft.EntityFrameworkCore;
using RentCarApp.Domain.SeedWork;
using RentCarApp.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentCarApp.Infrastructure.Domain
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly RentCarContext _context;
        internal DbSet<T> dbSet;

        public Repository(RentCarContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }
        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return entities;
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void UpdateRange(IEnumerable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {

            T entity = await dbSet.FindAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                _context.Set<T>().Update(entity);
                return true;
            }
            return false;
        }
        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includes != null)
            {
                query = query.IncludeMultiple(includes);
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAllNoTrackingAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includes != null)
            {
                query = query.IncludeMultiple(includes);
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.AsNoTracking().ToListAsync();
        }
        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includes != null)
            {
                query = query.IncludeMultiple(includes);
            }
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
