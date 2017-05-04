using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxDomainServices
{
    public interface ILogRepository<IEntityBase, ILogEntityBase, in TId> : ILogRepository<IEntityBase, TId> where IEntityBase : IEntityBase<TId>
           where ILogEntityBase : ILogEntityBase<TId>
    {
       
    }
}
