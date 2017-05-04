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
    public interface IEntityBase<TId>
    {
        [Key]
        TId Id { get; set; }
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
        string Status { get; set; }
        string UserSign { get; set; }
    }

    //public interface IDocumentEntityBase<TId>
    //{
    //    [Key]
    //    //TId Id { get; set; }
    //    //DateTime CreateDate { get; set; }
    //    //DateTime UpdateDate { get; set; }
    //    //string Status { get; set; }
    //    //string UserSign { get; set; }
    //}

    public interface IMasterDataBase<TId> : IEntityBase<TId>
    {
        
       
        [MaxLength(100)]
        string Name { get; set; }
    }

    
    public interface IDocumentBase<TId> :  IEntityBase<TId>
    {
        
        int DocNum { get; set; }
    }


}