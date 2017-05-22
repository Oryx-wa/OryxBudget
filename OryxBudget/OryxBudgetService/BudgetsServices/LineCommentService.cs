using Data.Infrastructure;
using Entities.Budgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories;
using OryxBudgetService;

namespace  OryxBudgetService.BudgetsServices
{
  public  class LineCommentService : BaseBudgetService<LineComment>
    {
        private readonly IBaseLogBudgetRepository<LineComment, LineCommentLog, Guid> _repository;

        public LineCommentService(IBaseLogBudgetRepository<LineComment, LineCommentLog, Guid> repository, IBudgetUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }

        public override void Update(LineComment entity)
        {
            LineComment dbLineComment = this.Get(entity.Id);



            base.Update(dbLineComment);

        }

        //public IEnumerable<LineComment> GetByLineCommentId(string lineCommentId)
        //{
        //    return this.GetAll().Where(info => info.BudgetLineId.ToString() == lineCommentId);
        //}


    }
}
