﻿using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tarefa5.Domain.Interfaces.Postgres;
using Tarefa5.Domain.Entity;
using Tarefa5.Data.Postgres.Context;

namespace Tarefa5.Data.Postgres.Repository
{
    public class RepositoryBase<K> : IRepositoryBase<K> where K : Base
    {
        protected readonly PostgresDbContext _context;

        public RepositoryBase(PostgresDbContext context)
        {
            _context = context;
        }

        public async Task<K?> GetAsync(bool tracking, Func<IQueryable<K>, IIncludableQueryable<K, object>>? include = null, Expression<Func<K, bool>>? predicate = null)
        {
            IQueryable<K> query = _context.Set<K>();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            if (include != null)
            {
                query = include(query);
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return await query.FirstOrDefaultAsync();
        }
        public void Attach<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Attach(entity);
        }

        public async Task<List<K>> GetAllAsync()
        {
            return await _context.Set<K>().ToListAsync();
        }

        public async Task<List<K>> GetFilteredAsync(bool tracking, Func<IQueryable<K>, IIncludableQueryable<K, object>>? include = null, Expression<Func<K, bool>>? predicate = null, Func<IQueryable<K>, IOrderedQueryable<K>>? orderBy = null, int? page = null, int? perPage = null)
        {
            IQueryable<K> query = _context.Set<K>();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            if (include != null)
            {
                query = include(query);
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (page.HasValue && perPage.HasValue)
            {
                query = query.Skip((page.Value - 1) * perPage.Value).Take(perPage.Value);
            }
            return await query.ToListAsync();
        }
        public async Task<K?> GetByIdAsync(Guid id)
        {
            return await _context.Set<K>().FindAsync(id);
        }

        public async Task<bool> ExistsAsync(Expression<Func<K, bool>> expression)
        {
            return await _context.Set<K>().AnyAsync(expression);
        }

        public async Task<long> CountAsync(Expression<Func<K, bool>> expression)
        {
            return await _context.Set<K>().CountAsync(expression);
        }

        public async Task<Guid> InsertAsync(K entity)
        {
            await _context.Set<K>().AddAsync(entity);
            return entity.Id;
        }


        public void Update(K entity)
        {
            entity.Update();
            _context.Set<K>().Update(entity);
        }

        public void Remove(K entity)
        {
            entity.Remove();
            _context.Set<K>().Attach(entity);
        }

        public void Delete(K entity)
        {
            _context.Set<K>().Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
