using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Valkyrie.Core.Extensions;



namespace Valkyrie.Data.Ef.Repository.Impl
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        public readonly TContext Context;
        private readonly DbSet<TEntity> _entities;

        #region ctor
        public Repository(TContext context)
        {
            Context = context;
            _entities = context.Set<TEntity>();
        }
        #endregion

        #region Sync Methods    

        private async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }

        private int SaveChanges()
        {
            return Context.SaveChanges();
        }
        #endregion

        #region Sync Methods              
        public TEntity Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entities.Add(entity);
            SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entities.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            SaveChanges();

            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entities.Attach(entity);
            Context.Entry(entity).State = EntityState.Deleted;
            SaveChanges();
            return entity;
        }

        public IEnumerable<TEntity> GetAll() =>
            _entities.AsNoTracking().AsEnumerable();

        public IQueryable<TEntity> QueryAble()
        {
            return _entities.AsQueryable();
        }

        public IQueryable<TEntity> QueryAble(Func<TEntity, bool> predicate)
        {
            return _entities.Where(predicate).AsQueryable();
        }

        public TEntity GetBy(Func<TEntity, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            var result = _entities.FirstOrDefault(predicate);
            return result;
        }

        public IList<TEntity> GetAllBy(Func<TEntity, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return _entities.Where(predicate).ToList();
        }

        public IQueryable<TEntity> GetAllByQ(Func<TEntity, bool> predicate)
        {
            return _entities.Where(predicate).AsQueryable();
        }

        public IEnumerable<TEntity> GetAllBy(
            Expression<Func<TEntity, bool>> filter = null,
            string[] includePaths = null,
            int? page = 0, int? pageSize = null,
            params SortExpression<TEntity>[] sortExpressions)
        {
            IQueryable<TEntity> query = _entities;

            if (filter != null)
            {
                query = query.AsNoTracking().Where(filter);
            }

            if (includePaths != null)
            {
                for (var i = 0; i < includePaths.Count(); i++)
                {
                    query = query.Include(includePaths[i]);
                }
            }

            if (sortExpressions != null)
            {
                IOrderedQueryable<TEntity> orderedQuery = null;
                for (var i = 0; i < sortExpressions.Count(); i++)
                {
                    if (i == 0)
                    {
                        orderedQuery = sortExpressions[i].SortDirection == ListSortDirection.Ascending ? query.OrderBy(sortExpressions[i].SortBy) : query.OrderByDescending(sortExpressions[i].SortBy);
                    }
                    else
                    {
                        orderedQuery = sortExpressions[i].SortDirection == ListSortDirection.Ascending ? orderedQuery.ThenBy(sortExpressions[i].SortBy) : orderedQuery.ThenByDescending(sortExpressions[i].SortBy);
                    }
                }

                if (page != null)
                {
                    query = orderedQuery.Skip(((int)page - 1) * (int)pageSize);
                }
            }

            if (pageSize != null)
            {
                query = query.Take((int)pageSize);
            }

            return query.ToList();
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.AsQueryable().Any(predicate);
        }

  
        public TModel ExecuteStoredProcedure<TModel>(string rawSql, params object[] paramList)
        {
            return default(TModel);
        }

        #endregion

        #region Async Methods      

        public async Task InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            await _entities.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entities.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _entities.Attach(entity);
            Context.Entry(entity).State = EntityState.Deleted;
            await SaveChangesAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync() =>
            await _entities.ToListAsync();

        public async Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            return await _entities.FirstOrDefaultAsync(predicate);
        }

        public async Task<IReadOnlyList<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            return await _entities.Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> filter, string[] includePaths, int? page = 0, int? pageSize = null, params SortExpression<TEntity>[] sortExpressions)
        {

            IQueryable<TEntity> query = _entities;

            if (filter != null)
            {
                query = query.AsNoTracking().Where(filter);
            }

            if (includePaths != null)
            {
                for (var i = 0; i < includePaths.Count(); i++)
                {
                    query = query.Include(includePaths[i]);
                }
            }

            if (sortExpressions != null)
            {
                IOrderedQueryable<TEntity> orderedQuery = null;
                for (var i = 0; i < sortExpressions.Count(); i++)
                {
                    if (i == 0)
                    {
                        orderedQuery = sortExpressions[i].SortDirection == ListSortDirection.Ascending ? query.OrderBy(sortExpressions[i].SortBy) : query.OrderByDescending(sortExpressions[i].SortBy);
                    }
                    else
                    {
                        orderedQuery = sortExpressions[i].SortDirection == ListSortDirection.Ascending ? orderedQuery.ThenBy(sortExpressions[i].SortBy) : orderedQuery.ThenByDescending(sortExpressions[i].SortBy);
                    }
                }

                if (page != null)
                {
                    if (pageSize != null) query = orderedQuery.Skip(((int)page - 1) * (int)pageSize);
                }
            }

            if (pageSize != null)
            {
                query = query.Take((int)pageSize);
            }
            return await query.ToListAsync();
        }

        #endregion
    }

}