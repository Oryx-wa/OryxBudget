using System;
using System.Linq;
using System.Linq.Expressions;
using OryxDomainServices;
using Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using OryxSecurity.Services;
using System.Collections.Generic;

namespace Data.Repositories
{
    public class BaseBudgetRepository<TEntity, TId> : IBaseBudgetRepository<TEntity, TId>
        where TEntity : class, IEntityBase<TId>, new()

    {

        protected OryxBudgetContext dataContext;
        protected readonly DbSet<TEntity> dbSet;
        protected IUserResolverService _userResolverService;

        #region Properties
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected OryxBudgetContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
        public BaseBudgetRepository(IDbFactory dbFactory, IUserResolverService UserResolverService)
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
            this.updateEntityForAdd(entity);
            dataContext.Add(entity);
        }

        public virtual void Add(TEntity entity, string userId)
        {
            this.updateEntityForAdd(entity, userId);
            dataContext.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            updateEntityForUpdate(entity);
            dbSet.Update(entity);
        }

        public bool Contains(TId id)
        {
            return GetAll().Any(x => x.Id.Equals(id));
        }

        public bool Contains(TId id, DateTime effectiveDate)
        {
            return GetAll().Any(x => x.Id.Equals(id) );
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

        public virtual void Remove(TId id)
        {
            dbSet.Remove(dbSet.Find(id));
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

        public IQueryable<TEntity> AllIncludingNoTracking(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = DbContext.Set<TEntity>().AsNoTracking();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        protected void updateEntityForAdd(TEntity entity, string userId = "")
        {
            if (!string.IsNullOrEmpty(userId))
            {
                entity.UserSign = userId;
            }
            else
            {
                string userName = _userResolverService.GetUser();
                entity.UserSign = userName;
            }                
            entity.UpdateDate = System.DateTime.Now;
            entity.CreateDate = System.DateTime.Now;
            entity.Status = "A";

        }

        protected void updateEntityForAdd(IEntityBase<TId> entity)
        {
            string userName = _userResolverService.GetUser();
            entity.UserSign = userName;
            entity.UpdateDate = System.DateTime.Now;
            entity.CreateDate = System.DateTime.Now;
            entity.Status = "A";

        }

        protected void updateEntityForAdd(IEnumerable<IEntityBase<TId>> entities)
        {
            foreach (var entity in entities)
            {
                //entity.UserSign = userName;
                //entity.UpdateDate = System.DateTime.Now;
                //entity.CreateDate = System.DateTime.Now;
                string userName = _userResolverService.GetUser();
                entity.UserSign = userName;
                entity.UpdateDate = System.DateTime.Now;
                entity.CreateDate = System.DateTime.Now;
                entity.Status = "A";
            }
            

        }

        protected void updateEntityForUpdate(IEntityBase<TId> entity)
        {
            string userName = _userResolverService.GetUser();
            entity.UserSign = userName;
            entity.UpdateDate = System.DateTime.Now;

        }

        protected void updateEntityForUpdate(IEnumerable<IEntityBase<TId>> entities)
        {
            foreach (var entity in entities)
            {
                string userName = _userResolverService.GetUser();
                entity.UserSign = userName;
                entity.UpdateDate = System.DateTime.Now;
            }
        }

        protected void updateEntityForAdd(ILogEntityBase<TId> entity)
        {
            string userName = _userResolverService.GetUser();
            entity.UserSign = userName;
            entity.UpdateDate = System.DateTime.Now;
            entity.CreateDate = System.DateTime.Now;
            //entity.Status = "A";

        }


        public void updateTracking(IEntityBase<TId> perm, EntityState state)
        {
            dataContext.Entry(perm).State = state;

            if (state == EntityState.Added)
            {
                this.updateEntityForAdd(perm);
            }
            else
            {
                this.updateEntityForUpdate(perm);
            }
        }
    }
}
public interface IBaseBudgetRepository<TEntity, TId> : ILogRepository<TEntity, TId>
    where TEntity : class, IEntityBase<TId>, new()
{

}
