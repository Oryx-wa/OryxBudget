using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxDomainServices
{
    public abstract class BaseServiceDecorator<TEntity, TId> : BaseService<TEntity, TId> where TEntity : IEntityBase<TId>
    {
        protected BaseService<TEntity, TId> _BaseService = null;
        protected BaseServiceDecorator(ILogRepository<TEntity, TId> repository, IUnitOfWork unitOfWork, BaseService<TEntity,TId> baseService)
            : base(repository, unitOfWork)
        {
            _BaseService = baseService;
        }
    }
}
