using Data.Infrastructure;
using Entities.Budgets;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.Text;
using OryxSecurity.Services;

namespace Data.Repositories.BudgetsRepositories
{
   public class LineCommentRepository : BaseLogBudgetRepository<LineComment, LineCommentLog, Guid>, ILogRepository<LineComment, Guid>
    {
        public LineCommentRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {
        }

        public override void Update(LineComment entity)
        {
            LineComment dbComment = this.Get(entity.Id);

            dbComment.Comment = entity.Comment;
            dbComment.CommentStatus = entity.CommentStatus;

            base.Update(dbComment);
        }

    }
}
