using Microsoft.EntityFrameworkCore;
using OryxDomainServices;
using System;
using System.Linq;
using OryxSecurity.Services;
using System.Linq.Expressions;
using OryxSecurity.Infrastructure;

namespace OryxSecurity.Repositories
{
    public class BaseSecurityRepository<TEntity, TId> : ILogRepository<TEntity, TId>
        where TEntity : class, IEntityBase<TId>, new()
    {
        protected SecurityContext dataContext;
        private readonly DbSet<TEntity> dbSet;
        private IUserResolverService _userResolverService;

        #region Properties
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected SecurityContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
        public BaseSecurityRepository(IDbFactory dbFactory, IUserResolverService UserResolverService)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<TEntity>();
            _userResolverService = UserResolverService;
        }
        #endregion

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual void Add(TEntity entity)
        {
            string userName = _userResolverService.GetUser();
            entity.UserSign = userName;
            entity.UpdateDate = System.DateTime.Now;
            entity.CreateDate = System.DateTime.Now;
            entity.Status = "Y";
            dataContext.Add(entity);
        }
        public virtual void Add(TEntity entity, string userId)
        {
            //this.updateEntityForAdd(entity, userId);
            dataContext.Add(entity);
        }
        public virtual void Update(TEntity entity)
        {
            string userName = _userResolverService.GetUser();
            entity.UserSign = userName;
            entity.UpdateDate = System.DateTime.Now;
            entity.Status = "Y";
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

       

        public virtual void Update(TEntity entity, string userId)
        {
            //updateEntityForUpdate(entity, userId);
            dbSet.Update(entity);
        }

        public bool Contains(TId id)
        {
            return GetAll().Any(x => x.Id.Equals(id));
        }
      

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(TId id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {

            return DbContext.Set<TEntity>();

        }

        public void Remove(TId id)
        {
            string userName = _userResolverService.GetUser();
            var entity = Get(id);
            entity.UserSign = userName;
            entity.UpdateDate = System.DateTime.Now;
            entity.Status = "N";
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }



        public IQueryable<TEntity> All()
        {

            return GetAll();

        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = DbContext.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
    }
}
