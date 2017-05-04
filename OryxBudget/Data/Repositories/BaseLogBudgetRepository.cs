using AutoMapper;
using OryxDomainServices;
using OryxSecurity.Services;
using Data.Infrastructure;
using System.Linq;

namespace Data.Repositories
{
    public class BaseLogBudgetRepository<TEntity, TLogEntity, TId> : BaseBudgetRepository<TEntity, TId>, IBaseLogBudgetRepository<TEntity, TLogEntity, TId>
        where TEntity : class, IEntityBase<TId>, new() where TLogEntity : class, ILogEntityBase<TId>, new()
    {
        private MapperConfiguration config;

        public BaseLogBudgetRepository(IDbFactory dbFactory, IUserResolverService UserResolverService)
            : base(dbFactory, UserResolverService)
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap(typeof(TEntity), typeof(TLogEntity)).ReverseMap();
            });


        }

        public override void Add(TEntity entity)
        {
            base.Add(entity);
            IMapper mapper = config.CreateMapper();
            var logEntity = mapper.Map<TLogEntity>(entity);
            logEntity.Id = entity.Id;
            dataContext.Add(logEntity);
        }

        

        public override void Update(TEntity entity)
        {
            base.Update(entity);
            IMapper mapper = config.CreateMapper();
            var logEntity = mapper.Map<TLogEntity>(entity);
            var count = this.getLogCount(logEntity);
            logEntity.LogInstance = count++;
            dataContext.Add(logEntity);
        }

        public TLogEntity UpdateWithLog(TEntity entity)
        {

            base.Update(entity);
            IMapper mapper = config.CreateMapper();

            var logEntity = mapper.Map<TLogEntity>(entity);
            var count = this.getLogCount(logEntity);
            logEntity.LogInstance = count++;
            dataContext.Add(logEntity);
            return logEntity;
        }

        private int getLogCount(TLogEntity entity)
        {
            return DbContext.Set<TLogEntity>().Where(log => log.Id.ToString() == entity.Id.ToString()).Count();
        }


    }

    public interface IBaseLogBudgetRepository<TEntity, TLogEntity, TId> : ILogRepository<TEntity, TLogEntity, TId>
   where TEntity : class, IEntityBase<TId>, new() where TLogEntity : class, ILogEntityBase<TId>, new()
    {

    }
}
