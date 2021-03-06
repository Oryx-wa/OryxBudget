﻿using System;
using System.Collections.Generic;
using OryxDomainServices;
using System.ComponentModel.DataAnnotations;


namespace Entities.Budgets
{
    public class LineComment : IEntityBase<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }
        [Required]
        [MaxLength(15)]
        public string UserType { get; set; }

        public Guid? BudgetId { get; set; }
        [Required]
        [MaxLength(355)]
        public string Comment { get; set; }
        public CommentStatus CommentStatus { get; set; }

        public string UserName { get; set; }
        public string UserEmail { get; set; }
        
        public string Code { get; set; }
        public BudgetStatus CommentType { get; set;  }

    }

    public class LineCommentLog : IEntityBase<Guid>, ILogEntityBase<Guid>
    {

        public int LogInstance { get; set; }       
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }
        [MaxLength(15)]
        public string UserType { get; set; }
        public Guid? BudgetId { get; set; }
        [MaxLength(355)]
        public string Comment { get; set; }
        public CommentStatus CommentStatus { get; set; }


        public string UserName { get; set; }
        public string UserEmail { get; set; }

        public string Code { get; set; }
        public BudgetStatus CommentType { get; set; }

    }

    public enum CommentStatus
    {
        New = 0,
        Accepted = 1,
        Parked = 2,
        [Display(Name = "Under Review")]
        UnderReview = 3
    }

    public enum UserType
    {
        Napims = 1,
        Operator = 2
    }
}
