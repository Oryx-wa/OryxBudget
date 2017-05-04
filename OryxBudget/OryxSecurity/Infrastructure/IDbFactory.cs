using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OryxSecurity.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        SecurityContext Init();
    }

}
