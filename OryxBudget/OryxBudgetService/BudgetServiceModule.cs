using Autofac;
using OryxDomainServices;
using Data.Repositories;
using Data.Infrastructure;
using OryxBudgetService.BudgetsServices;
using OryxBudgetService.Utilities.SignalRHubs;

namespace OryxBudgetService
{
    public class BudgetServiceModule : Module
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

            //builder.RegisterType<NotificationHub>()
            //    .As<IHubTrackingService>();

            builder.RegisterType<BudgetService>();
            builder.RegisterType<PeriodService>();
            builder.RegisterType<LineCommentService>();
            builder.RegisterType<BudgetLineService>();
            builder.RegisterType<CategoryService>();
            builder.RegisterType<BudgetCodeService>();
            //builder.RegisterType<AttachmentService>();


        }
    }
}
