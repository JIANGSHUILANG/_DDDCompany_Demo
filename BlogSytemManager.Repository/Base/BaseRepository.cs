using BlogSytemManager.DomainObject;
using BlogSytemManager.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSytemManager.Infrastructure.ExpressionHelper;
namespace BolgSytemManager.Domain.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : AggregateRoot
    {

        public IEFUnitOfWork UnitOfWork
        {
            get
            {
                return new EFUnitOfWork();
            }
            set
            {
                UnitOfWork = value;
            }
        }

        public virtual IQueryable<TEntity> Entites
        {
            get { return UnitOfWork.context.Set<TEntity>(); }
        }

        public System.Data.Entity.DbContext db
        {
            get
            {
                return UnitOfWork.context;
            }
            set
            {
                db = value;
            }
        }

        //public EFBaseRepository()
        //{
        //    //注册MEF
        //    Register.regisgter().ComposeParts(this);
        //}


        #region Methods Realize 方法实现

        public virtual TEntity Add(TEntity entity)
        {
            UnitOfWork.RegisterNew<TEntity>(entity);
            UnitOfWork.Commit();
            return entity;
        }

        public virtual int Add(IEnumerable<TEntity> entities)
        {
            foreach (var obj in entities)
            {
                UnitOfWork.RegisterNew(obj);
            }
            return UnitOfWork.Commit();
        }

        public virtual int Delete(object id)
        {
            var obj = UnitOfWork.context.Set<TEntity>().Find(id);
            if (obj == null)
            {
                return 0;
            }
            UnitOfWork.RegisterDeleted(obj);
            return UnitOfWork.Commit();
        }

        public virtual int Delete(TEntity entity)
        {
            UnitOfWork.RegisterDeleted(entity);
            return UnitOfWork.Commit();
        }

        public virtual int Delete(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                UnitOfWork.RegisterDeleted(entity);
            }
            return UnitOfWork.Commit();
        }

        public virtual int Delete(System.Linq.Expressions.Expression<Func<TEntity, bool>> express)
        {
            Func<TEntity, bool> lamda = express.Compile();
            var del = UnitOfWork.context.Set<TEntity>().Where(lamda);
            foreach (var entity in del)
            {
                UnitOfWork.RegisterDeleted<TEntity>(entity);
            }
            return UnitOfWork.Commit();
        }

        public virtual int Update(TEntity entity)
        {
            UnitOfWork.RegisterModified(entity);
            return UnitOfWork.Commit();
        }

        public virtual TEntity GetByKey(object key)
        {
            return UnitOfWork.context.Set<TEntity>().Find(key);
        }

        public virtual IQueryable<TEntity> LoadEnities(System.Linq.Expressions.Expression<Func<TEntity, bool>> WhereLamda)
        {
            return UnitOfWork.context.Set<TEntity>().Where<TEntity>(WhereLamda);
        }

        public virtual IQueryable<TEntity> LoadPageEnities<S>(int PageIndex, int PageSize, out int TotalCount, System.Linq.Expressions.Expression<Func<TEntity, bool>> WhereLamda, System.Linq.Expressions.Expression<Func<TEntity, S>> OrderLamda, bool Asc = true)
        {

            var tempList = UnitOfWork.context.Set<TEntity>().Where<TEntity>(WhereLamda);
            TotalCount = tempList.Count();
            IQueryable<TEntity> resultList = null;
            if (OrderLamda != null)
            {
                if (Asc)
                {
                    resultList = tempList.OrderBy<TEntity, S>(OrderLamda).Skip<TEntity>((PageIndex - 1) * PageSize).Take<TEntity>(PageSize);
                }
                else
                {
                    resultList = tempList.OrderByDescending<TEntity, S>(OrderLamda).Skip<TEntity>((PageIndex - 1) * PageSize).Take<TEntity>(PageSize);
                }
            }
            else
            {
                resultList = tempList.Skip<TEntity>((PageIndex - 1) * PageSize).Take<TEntity>(PageSize);
            }

            return resultList;
        }
        #endregion

        public IQueryable<DTO> LoadEntities<DTO>(System.Linq.Expressions.Expression<Func<TEntity, bool>> whereLambda) where DTO : BaseObject
        {
            return UnitOfWork.context.Set<TEntity>().Project().To<DTO>();
        }

    }

    public static class RepositoryHelper
    {
        //public static IQueryable<DTO> GetDTO<DTO,Entity>(this IQueryable<Entity> TSoure)
        //{ 
        
        //}
    }
}
