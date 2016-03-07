using DDDCompany.Domain.BaseModel;
using DDDCompany.Domain.IRepositories.Base;
using DDDCompany.Infrastructure.MEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace DDDCompany.Repository.Repositories.Base
{
    /// <summary>
    /// 仓储的泛型实现
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// 仓储实现基类的所有方法加上virtual关键字，方便具体的仓储在特定需求的时候override基类的方法
    public class EFBaseRepository<TEntity> : IRepository<TEntity> where TEntity : AggregateRoot
    {
        [Import(typeof(IEFUnitOfWork))]
        public IEFUnitOfWork UnitOfWork { get; set; }

        public virtual IQueryable<TEntity> Entites
        {
            get { return UnitOfWork.context.Set<TEntity>(); }
        }



        public EFBaseRepository()
        {
            //注册MEF
            Register.regisgter().ComposeParts(this);
        }


        #region Methods Realize 方法实现

        public virtual int Add(TEntity entity)
        {
            UnitOfWork.RegisterNew<TEntity>(entity);
            return UnitOfWork.Commit();
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
            if (Asc)
            {
                resultList = tempList.OrderBy<TEntity, S>(OrderLamda).Skip<TEntity>((PageIndex - 1) * PageSize).Take<TEntity>(PageSize);
            }
            else
            {
                resultList = tempList.OrderByDescending<TEntity, S>(OrderLamda).Skip<TEntity>((PageIndex - 1) * PageSize).Take<TEntity>(PageSize);
            }

            return resultList;
        }
        #endregion



    }
}
