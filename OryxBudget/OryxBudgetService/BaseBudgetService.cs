using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OryxBudgetService
{
    public abstract class BaseBudgetService<TEntity> : BaseService<TEntity, Guid>
        where TEntity : class, IEntityBase<Guid>, new()
    {
        public BaseBudgetService(ILogRepository<TEntity, Guid> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
        }

        public override void Add(TEntity entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
            this.Validate(entity);
            base.Add(entity);
        }

        

        public override void Add(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.Id == Guid.Empty)
                {
                    this.Add(entity);
                }
                else
                {
                    this.Update(entity);
                }
            }        
           
        }

        public override void Add(IEnumerable<TEntity> entities,  DateTime effectiveDate)
        {
            foreach (var entity in entities)
            {
                if (entity.Id == Guid.Empty)
                {
                    this.Add(entity, effectiveDate);
                }
                
            }

        }
        public override void Add(TEntity entity, DateTime effectiveDate)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
                this.Validate(entity);
                base.Add(entity, effectiveDate);
            }
          
        }
      
        protected virtual void Validate(TEntity entity)
        {

        }
       
    }
}
