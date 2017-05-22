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
            var sql = $@"Select SUM(a.OpBudgetFC) OpBudgetFC, SUM(a.OpBudgetUSD) OpBudgetUSD , SUM(a.OpBudgetLC) OpBudgetLC,
	SUM(a.SubComBudgetFC) SubComBudgetFC, SUM(a.SubComBudgetLC) SubComBudgetLC, SUM(a.SubComBudgetUSD) SubComBudgetUSD, 
	SUM(a.TecComBudgetFC) TecComBudgetFC, SUM(a.TecComBudgetLC) TecComBudgetLC, SUM(a.TecComBudgetUSD) TecComBudgetUSD,
	SUM(a.MalComBudgetFC) MalComBudgetFC, SUM(a.MalComBudgetLC) MalComBudgetLC, SUM(a.MalComBudgetUSD) MalComBudgetUSD,
	SUM(a.FinalBudgetFC) FinalBudgetFC, SUM(a.FinalBudgetLC) FinalBudgetLC, SUM(a.FinalBudgetUSD) FinalBudgetUSD, 
	f.OperatorId, f.Description, f.Id, g.Name OperatorName
from Budgets f join BudgetLines a 
	on f.id = a.BudgetId
	join Operators g on f.OperatorId = g.id
where f.OperatorId = '{OperatorId}'
Group by f.OperatorId, f.Description, f.id";

            return RDFacadeExtensions.GetModelFromQuery<OperatorBudget>(this.dataContext.Database, sql);
        }

        public IEnumerable<BudgetCodeView> GetBudgetLines(string id)
        {
            var sql = $@"Select SUM(a.OpBudgetFC) OpBudgetFC, SUM(a.OpBudgetUSD) OpBudgetUSD , SUM(a.OpBudgetLC) OpBudgetLC,
	SUM(a.SubComBudgetFC) SubComBudgetFC, SUM(a.SubComBudgetLC) SubComBudgetLC, SUM(a.SubComBudgetUSD) SubComBudgetUSD, 
	SUM(a.TecComBudgetFC) TecComBudgetFC, SUM(a.TecComBudgetLC) TecComBudgetLC, SUM(a.TecComBudgetUSD) TecComBudgetUSD,
	SUM(a.MalComBudgetFC) MalComBudgetFC, SUM(a.MalComBudgetLC) MalComBudgetLC, SUM(a.MalComBudgetUSD) MalComBudgetUSD,
	SUM(a.FinalBudgetFC) FinalBudgetFC, SUM(a.FinalBudgetLC) FinalBudgetLC, SUM(a.FinalBudgetUSD) FinalBudgetUSD, 
	f.OperatorId,  f.Id, g.Name OperatorName, h.Code, h.Description, h.FatherNum, h.Level
from Budgets f join BudgetLines a 
	on f.id = a.BudgetId
	join Operators g on f.OperatorId = g.id
	join BudgetCodes h on a.Code = h.Code
where f.id = '{id}'
Group by f.OperatorId,  f.id,h.Code, h.Description, h.FatherNum, h.Level, g.Name
union all
Select SUM(a.OpBudgetFC) OpBudgetFC, SUM(a.OpBudgetUSD) OpBudgetUSD , SUM(a.OpBudgetLC) OpBudgetLC,
	SUM(a.SubComBudgetFC) SubComBudgetFC, SUM(a.SubComBudgetLC) SubComBudgetLC, SUM(a.SubComBudgetUSD) SubComBudgetUSD, 
	SUM(a.TecComBudgetFC) TecComBudgetFC, SUM(a.TecComBudgetLC) TecComBudgetLC, SUM(a.TecComBudgetUSD) TecComBudgetUSD,
	SUM(a.MalComBudgetFC) MalComBudgetFC, SUM(a.MalComBudgetLC) MalComBudgetLC, SUM(a.MalComBudgetUSD) MalComBudgetUSD,
	SUM(a.FinalBudgetFC) FinalBudgetFC, SUM(a.FinalBudgetLC) FinalBudgetLC, SUM(a.FinalBudgetUSD) FinalBudgetUSD, 
	f.OperatorId,  f.Id, g.Name OperatorName, h.level2, h.Description, h.FatherNum, h.Level
from Budgets f join BudgetLines a 
	on f.id = a.BudgetId
	join Operators g on f.OperatorId = g.id
	join (Select a.Code,  b.Description, b.Level, b.code level2, b.FatherNum 
from BudgetCodes a join BudgetCodes b
	on a.FatherNum = b.Code
where a.Level = '3') h on a.Code = h.Code
where f.id = '{id}'
Group by f.OperatorId,  f.id,h.level2, h.Description, h.FatherNum, h.Level, g.Name
union all
Select SUM(a.OpBudgetFC) OpBudgetFC, SUM(a.OpBudgetUSD) OpBudgetUSD , SUM(a.OpBudgetLC) OpBudgetLC,
	SUM(a.SubComBudgetFC) SubComBudgetFC, SUM(a.SubComBudgetLC) SubComBudgetLC, SUM(a.SubComBudgetUSD) SubComBudgetUSD, 
	SUM(a.TecComBudgetFC) TecComBudgetFC, SUM(a.TecComBudgetLC) TecComBudgetLC, SUM(a.TecComBudgetUSD) TecComBudgetUSD,
	SUM(a.MalComBudgetFC) MalComBudgetFC, SUM(a.MalComBudgetLC) MalComBudgetLC, SUM(a.MalComBudgetUSD) MalComBudgetUSD,
	SUM(a.FinalBudgetFC) FinalBudgetFC, SUM(a.FinalBudgetLC) FinalBudgetLC, SUM(a.FinalBudgetUSD) FinalBudgetUSD, 
	f.OperatorId,  f.Id, g.Name OperatorName, h.level2, h.Description, h.FatherNum, h.Level
from Budgets f join BudgetLines a 
	on f.id = a.BudgetId
	join Operators g on f.OperatorId = g.id
	join (Select a.Code,  b.Description, b.Level, b.code level2, b.FatherNum 
from BudgetCodes a join BudgetCodes b
	on a.level1 = b.Code) h on a.Code = h.Code
where f.id = '{id}'
Group by f.OperatorId,  f.id,h.level2, h.Description, h.FatherNum, h.Level, g.Name";

            return RDFacadeExtensions.GetModelFromQuery<BudgetCodeView>(this.dataContext.Database, sql);
        }


    }


}