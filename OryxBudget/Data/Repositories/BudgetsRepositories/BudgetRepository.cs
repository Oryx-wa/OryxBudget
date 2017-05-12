using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Budgets;
using OryxSecurity.Services;
using OryxDomainServices;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.BudgetsRepositories
{
    public class BudgetRepository : BaseLogBudgetRepository<Budget, BudgetLog, Guid>, ILogRepository<Budget, Guid>
    {
        public BudgetRepository(IDbFactory dbFactory, IUserResolverService UserResolverService) : base(dbFactory, UserResolverService)
        {

        }

        public IEnumerable<BudgetActuals> GetBudgetActuals (string budgetId)
        {
            var sql = $@" Select a.Code, SUM(a.AmountUSD + a.AmountLCInUSD) Budget, SUM(a.AmountUSD) BudgetUSD , SUM(a.AmountLC) BudgetLC, SUM(a.AmountLCInUSD) BudgetLCInUSD,
SUM(b.AmountLC) ActualLC,  SUM(b.AmountUSD) ActualUSD, SUM(b.AmountLCInUSD + b.AmountUSD) Actual from BudgetLines a left outer join Actuals b 
on a.BudgetId = b.BudgetId and a.Code = b.Code where a.BudgetId = '{budgetId}' Group by a.Code
union all
Select c.level1 , SUM(a.AmountUSD + a.AmountLCInUSD) Budget, SUM(a.AmountUSD) BudgetUSD , SUM(a.AmountLC) BudgetLC, SUM(a.AmountLCInUSD) BudgetLCInUSD,
	SUM(b.AmountLC) ActualLC,  SUM(b.AmountUSD) ActualUSD, SUM(b.AmountLCInUSD + b.AmountUSD) Actual
from BudgetLines a left outer join Actuals b 
	on a.BudgetId = b.BudgetId and a.Code = b.Code
	join BudgetCodes c on a.Code = c.Code	
where a.BudgetId = '{budgetId}'
Group by c.level1
union all
Select c.level2 , SUM(a.AmountUSD + a.AmountLCInUSD) Budget, SUM(a.AmountUSD) BudgetUSD , SUM(a.AmountLC) BudgetLC, SUM(a.AmountLCInUSD) BudgetLCInUSD,
	SUM(b.AmountLC) ActualLC,  SUM(b.AmountUSD) ActualUSD, SUM(b.AmountLCInUSD + b.AmountUSD) Actual
from BudgetLines a left outer join Actuals b 
	on a.BudgetId = b.BudgetId and a.Code = b.Code
	join BudgetCodes c on a.Code = c.Code	
where a.BudgetId = '{budgetId}'
Group by c.level2
Order By 1";

            return RDFacadeExtensions.GetModelFromQuery<BudgetActuals>(this.dataContext.Database, sql);
        }

        public IEnumerable<OperatorBudget> GetOperatorBudget(string OperatorId)
        {
            var sql = $@"Select SUM(a.AmountUSD + a.AmountLCInUSD) Budget, SUM(a.AmountUSD) BudgetUSD , SUM(a.AmountLC) BudgetLC,
	f.OperatorId, f.Description, f.Id
from Budgets f join BudgetLines a 
	on f.id = a.BudgetId
where f.OperatorId = '{OperatorId}'
Group by f.OperatorId, f.Description, f.id";

            return RDFacadeExtensions.GetModelFromQuery<OperatorBudget>(this.dataContext.Database, sql);
        }


    }


}