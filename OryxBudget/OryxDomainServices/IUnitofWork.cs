using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxDomainServices
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
