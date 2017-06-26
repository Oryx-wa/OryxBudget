using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxDomainServices
{
    /// <summary>
    /// Generic entity repository abstraction.  
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TId">The entity ID type.</typeparam>
    public interface ILogRepository<IEntityBase, in TId> : IReadOnlyRepository<IEntityBase, TId> where IEntityBase : IEntityBase<TId> 
           
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(IEntityBase entity);
        void Add(IEntityBase entity, string userId);

        /// <summary>
        /// Removes the entity with the specified id.
        /// </summary>
        /// <param name="id">The entity id.</param>
        void Remove(TId id);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(IEntityBase entity);
        void Update(IEntityBase entity, string userId);
    }
}
