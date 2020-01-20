using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Valkyrie.Core.Extensions;

namespace Valkyrie.Data.Ef.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Sync Methods

        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);

        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> QueryAble();
        IQueryable<TEntity> QueryAble(Func<TEntity, bool> predicate);
        TEntity GetBy(Func<TEntity, bool> predicate);
        IList<TEntity> GetAllBy(Func<TEntity, bool> predicate);
        IQueryable<TEntity> GetAllByQ(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetAllBy(
            Expression<Func<TEntity, bool>> filter = null,
            string[] includePaths = null,
            int? page = 0, int? pageSize = null,
            params SortExpression<TEntity>[] sortExpressions);

        bool Exists(Expression<Func<TEntity, bool>> predicate);

        TModel ExecuteStoredProcedure<TModel>(string rawSql, params object[] paramList);


        #endregion

        #region Async Methods

        Task InsertAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);

        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IReadOnlyList<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IReadOnlyList<TEntity>> GetAllByAsync(
            Expression<Func<TEntity, bool>> predicate,
            string[] includePaths = null,
            int? page = 0, int? pageSize = null,
            params SortExpression<TEntity>[] sortExpressions);
        #endregion
    }
}