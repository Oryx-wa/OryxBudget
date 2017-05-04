namespace OryxDomainServices
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Abstract base class for a service.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TId">The entity ID type.</typeparam>
    public abstract class BaseService<TEntity, TId> : BaseReadOnlyService<TEntity, TId> where TEntity : IEntityBase<TId>
    {
        private readonly ILogRepository<TEntity, TId> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        protected ILogEntityBase<TId> _LogTable;
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseBudgetServices{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if repository is null.</exception>
        protected BaseService(ILogRepository<TEntity, TId> repository, IUnitOfWork unitOfWork)
            : base(repository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
           
        }

        public virtual void Remove(TId id)
        {
            if (_repository.Contains(id))
            {

                _repository.Remove(id);

            }
            else
            {
                throw new KeyNotFoundException(string.Format("{0} with id {1} was not found", typeof(TEntity), id));
            }
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.ArgumentException">Thrown if an entity with the same id already exists.</exception>
        public virtual void Add(TEntity entity)
        {
            if (!_repository.Contains(entity.Id))
            {
                _repository.Add(entity);
            }
            else
            {
                throw new ArgumentException(string.Format("{0} with id {1} already exists", typeof(TEntity), entity.Id));
            }
        }

        public virtual void Add(TEntity entity, DateTime effectiveDate)
        {
            if (!_repository.Contains(entity.Id))
            {
               // entity.EffectiveDate = effectiveDate.Date;
                _repository.Add(entity);
            }
            else
            {
                throw new ArgumentException(string.Format("{0} with id {1} already exists", typeof(TEntity), entity.Id));
            }
        }
      //  public virtual void Add(TEntity entity, string userId)
       // {
       //     if (!_repository.Contains(entity.Id))
       //     {
       //         _repository.Add(entity, userId);
       //     }
        //    else
        //    {
         //       throw new ArgumentException(string.Format("{0} with id {1} already exists", typeof(TEntity), entity.Id));
          //  }
      //  }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                this.Add(item);
            }
        }

        public virtual void Add(IEnumerable<TEntity> entities, DateTime effectiveDate)
        {
            foreach (var item in entities)
            {
                this.Add(item, effectiveDate);
            }
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Thrown if entity with the given id is not found.</exception>
        public virtual void Update(TEntity entity)
        {
            if (_repository.Contains(entity.Id))
            {
                _repository.Update(entity);

            }
            else
            {
                throw new KeyNotFoundException(string.Format("{0} with id {1} was not found", typeof(TEntity), entity.Id));
            }
        }

        public virtual void SaveChanges()
        {
            _unitOfWork.Commit();
        }

      //  public virtual bool effectiveDateExists(TEntity entity, DateTime effectiveDate)
      //  {
      //      return _repository.Contains(entity.Id, effectiveDate);
      //  }



    }
}
