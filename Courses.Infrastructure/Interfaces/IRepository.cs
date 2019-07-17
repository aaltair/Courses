using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Courses.Infrastructure.Interfaces
{
   public interface IRepository<TEntity>
    {
        /// <summary>
        /// Get entity by id.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <returns>Entity object.</returns>
        TEntity GetById(object id);

        /// <summary>
        /// Get all entities.
        /// </summary>
        /// <returns>IEnumerable collection of entities.</returns>
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties
        , int? pageIndex, int? pageSize);

        /// <summary>
        /// Find entity by predicate.
        /// </summary>
        /// <param name="predicate">Predicate expression.</param>
        /// <returns>IEnumerable collection of entities.</returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Add entity.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Add range of entities.
        /// </summary>
        /// <param name="entities">IEnumerable collection of entities.</param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Remove entity.
        /// </summary>
        /// <param name="entity">Entity object.</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Remove range of entities.
        /// </summary>
        /// <param name="entities">IEnumerable collection of entities.</param>
        void RemoveRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Get entities count.
        /// </summary>
        /// <returns>Entities count.</returns>
        int Count();

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null);
    }
}