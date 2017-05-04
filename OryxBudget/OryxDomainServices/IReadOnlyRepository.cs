using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OryxDomainServices
{
    /// <summary>
    /// Generic read-only entity repository abstraction.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TId">The entity ID type.</typeparam>
    public interface IReadOnlyRepository<IEntityBase, in TId> where IEntityBase : IEntityBase<TId>
    {
        /// <summary>
        /// Gets the number of entities in the repository.
        /// </summary>
        /// <returns>The total number of entities.</returns>
        int Count { get; }

        /// <summary>
        /// Determines whether the repository contains an entity with the specified id.
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <returns><c>true</c> if the repository contains an entity with the specified id; otherwise, <c>false</c>.</returns>
        bool Contains(TId id);
        //bool Contains(TId id, DateTime effectiveDate);

        /// <summary>
        /// Gets the entity with the specified id.
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <returns>The entity.</returns>
        IEntityBase Get(TId id);

        /// <summary>
        /// Filters the entities based on the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>IQueryable{TEntity}.</returns>
        IQueryable<IEntityBase> Get(Expression<Func<IEntityBase, bool>> predicate);

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>A list of entities.</returns>
        IQueryable<IEntityBase> GetAll();

        IQueryable<IEntityBase> All();

        IQueryable<IEntityBase> FindBy(Expression<Func<IEntityBase, bool>> predicate);

        IQueryable<IEntityBase> AllIncluding(params Expression<Func<IEntityBase, object>>[] includeProperties);
    }
}
