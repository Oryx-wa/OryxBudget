using Autofac;
using OryxDomainServices;
using Data.Repositories;
using Data.Infrastructure;
using OryxBudgetService.OperatorsServices;

namespace OryxBudgetService
{
    class OperatorServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(BaseBudgetRepository<,>))
               .As(typeof(ILogRepository<,>))
               .InstancePerLifetimeScope();
            //  .InstancePerBackgroundJob();

            builder.RegisterGeneric(typeof(IBaseLogBudgetRepository<,,>))
               .As(typeof(ILogRepository<,,>))
               .InstancePerLifetimeScope();
            //.InstancePerBackgroundJob();

            builder.RegisterType<BudgetUnitOfWork>()
                .As<IBudgetUnitOfWork>()
                .InstancePerLifetimeScope();
            //.InstancePerBackgroundJob();

            builder.RegisterType<DbFactory>()
                .As<IDbFactory>()
                .InstancePerLifetimeScope();
            //.InstancePerBackgroundJob();



            builder.RegisterType<OperatorService>();
            builder.RegisterType<OperatorTypeService>();
            builder.RegisterType<ContactPersonService>();
          
        }
    }
}
