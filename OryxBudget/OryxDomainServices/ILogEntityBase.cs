using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OryxDomainServices
{
    // <summary>
    /// Entity abstraction.
    /// </summary>
    /// <typeparam name="TId">The entity ID type.</typeparam>
    public interface ILogEntityBase<TId>
    {
        
        int LogInstance { get; set; }
        TId Id { get; set; }
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
        string UserSign { get; set; }
    }

    public interface ILogMasterDataBase<TId> : ILogEntityBase<TId>
    {
        
       
        [MaxLength(100)]
        string Name { get; set; }
    }

    
    public interface ILogDocumentBase<TId> : ILogEntityBase<TId>
    {
        
        int DocNum { get; set; }
    }
}