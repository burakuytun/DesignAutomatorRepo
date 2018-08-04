﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CrossCutting.Utils.Interfaces;
using CrossCutting.Utils.PagedList;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure.EntityFrameworkCore
{
    public class EntityFrameworkCoreRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected EntityFrameworkCoreRepository(DbContext context)
        {
            Context = context;
            Context.ChangeTracker.AutoDetectChangesEnabled = false;
            Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public IQueryable<TEntity> Queryable => Set.AsNoTracking();

        private DbSet<TEntity> Set => Context.Set<TEntity>();

        private DbContext Context { get; }

        public void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await Set.AddAsync(entity).ConfigureAwait(false);
        }

        public void AddRange(params TEntity[] entities)
        {
            Set.AddRange(entities);
        }

        public async Task AddRangeAsync(params TEntity[] entities)
        {
            await Set.AddRangeAsync(entities).ConfigureAwait(false);
        }

        public bool Any()
        {
            return Set.Any();
        }

        public bool Any(Expression<Func<TEntity, bool>> where)
        {
            return Set.Any(where);
        }

        public Task<bool> AnyAsync()
        {
            return Set.AnyAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where)
        {
            return Set.AnyAsync(where);
        }

        public long Count()
        {
            return Set.LongCount();
        }

        public long Count(Expression<Func<TEntity, bool>> where)
        {
            return Set.LongCount(where);
        }

        public Task<long> CountAsync()
        {
            return Set.LongCountAsync();
        }

        public Task<long> CountAsync(Expression<Func<TEntity, bool>> where)
        {
            return Set.LongCountAsync(where);
        }

        public void Delete(object key)
        {
            var entity = Set.Find(key);

            if (entity == null)
            {
                return;
            }

            Set.Remove(entity);
        }

        public TEntity FirstOrDefault(params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableInclude(include).FirstOrDefault();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableWhereInclude(where, include).FirstOrDefault();
        }

        public Task<TEntity> FirstOrDefaultAsync(params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableInclude(include).FirstOrDefaultAsync();
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableWhereInclude(where, include).FirstOrDefaultAsync();
        }

        public TEntityResult FirstOrDefaultResult<TEntityResult>(Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).FirstOrDefault();
        }

        public Task<TEntityResult> FirstOrDefaultResultAsync<TEntityResult>(Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).FirstOrDefaultAsync();
        }

        public TEntity LastOrDefault(params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableInclude(include).LastOrDefault();
        }

        public TEntity LastOrDefault(Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableWhereInclude(where, include).LastOrDefault();
        }

        public Task<TEntity> LastOrDefaultAsync(params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableInclude(include).LastOrDefaultAsync();
        }

        public Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableWhereInclude(where, include).LastOrDefaultAsync();
        }

        public TEntityResult LastOrDefaultResult<TEntityResult>(Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).LastOrDefault();
        }

        public Task<TEntityResult> LastOrDefaultResultAsync<TEntityResult>(Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).LastOrDefaultAsync();
        }

        public IEnumerable<TEntity> List(params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableInclude(include).ToList();
        }

        public IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableWhereInclude(where, include).ToList();
        }

        public PagedList<TEntity> List(PagedListParameters parameters,
            params Expression<Func<TEntity, object>>[] include)
        {
            return new PagedList<TEntity>(QueryableInclude(include), parameters);
        }

        public PagedList<TEntity> List(PagedListParameters parameters, Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] include)
        {
            return new PagedList<TEntity>(QueryableWhereInclude(where, include), parameters);
        }

        public async Task<IEnumerable<TEntity>> ListAsync(params Expression<Func<TEntity, object>>[] include)
        {
            return await QueryableInclude(include).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] include)
        {
            return await QueryableWhereInclude(where, include).ToListAsync().ConfigureAwait(false);
        }

        public TEntity Select(long id)
        {
            return Set.Find(id);
        }

        public Task<TEntity> SelectAsync(long id)
        {
            return Set.FindAsync(id);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableWhereInclude(where, include).SingleOrDefault();
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] include)
        {
            return QueryableWhereInclude(where, include).SingleOrDefaultAsync();
        }

        public TEntityResult SingleOrDefaultResult<TEntityResult>(Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).SingleOrDefault();
        }

        public Task<TEntityResult> SingleOrDefaultResultAsync<TEntityResult>(Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TEntityResult>> select)
        {
            return QueryableWhereSelect(where, select).SingleOrDefaultAsync();
        }

        public void Update(TEntity entity, object key)
        {
            var entityContext = Set.Find(key);

            if (entityContext != null)
            {
                Context.Entry(entityContext).CurrentValues.SetValues(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
        }

        private IQueryable<TEntity> Include(IQueryable<TEntity> queryable,
            Expression<Func<TEntity, object>>[] properties)
        {
            properties?.ToList().ForEach(property => queryable = queryable.Include(property));
            return queryable;
        }

        private IQueryable<TEntity> QueryableInclude(Expression<Func<TEntity, object>>[] include)
        {
            return Include(Queryable, include);
        }

        private IQueryable<TEntity> QueryableWhereInclude(Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, object>>[] include)
        {
            return Include(Queryable.Where(where), include);
        }

        private IQueryable<TEntityResult> QueryableWhereSelect<TEntityResult>(Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TEntityResult>> select)
        {
            return Queryable.Where(where).Select(select);
        }

        public TResult GetFirstOrDefaultWithDeepSelect<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = Queryable;
          
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
                return orderBy(query).Select(selector).FirstOrDefault();
            }
            else
            {
                return query.Select(selector).FirstOrDefault();
            }
        }

        public List<TResult> GetListWithDeepSelect<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = Queryable;
           
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
                return orderBy(query).Select(selector).ToList();
            }
            else
            {
                return query.Select(selector).ToList();
            }
        }
    }
}