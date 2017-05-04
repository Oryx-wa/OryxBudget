using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
//using Hangfire;
using Data.Repositories;
using Data.Infrastructure;
using Data.Repositories.BudgetsRepositories;
using OryxHR.Data.Repositories.BudgetsRepositories;

namespace Data
{
    public class BudgetDataModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(BaseBudgetRepository<,>))
               .As(typeof(IBaseBudgetRepository<,>))
               .InstancePerLifetimeScope();
            // .InstancePerBackgroundJob();

            builder.RegisterGeneric(typeof(BaseLogBudgetRepository<,,>))
               .As(typeof(IBaseLogBudgetRepository<,,>))
               .InstancePerLifetimeScope();
            //.InstancePerBackgroundJob(); 

            builder.RegisterType<BudgetUnitOfWork>()
                .As<IBudgetUnitOfWork>()
                .InstancePerLifetimeScope();
                //.InstancePerBackgroundJob();

            //builder.RegisterType<BudgetDefinitionItemRepository>();

            builder.RegisterType<BudgetRunRepository>();
            builder.RegisterType<BudgetRepository>();
           builder.RegisterType<BudgetLineRepository>();
            builder.RegisterType<BudgetLineCategoryRepository>();
            builder.RegisterType<PeriodRepository>();
            builder.RegisterType<ActualsRepository>();
          


        }
    }
}
