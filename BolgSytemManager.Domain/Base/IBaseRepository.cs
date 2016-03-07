using BlogSytemManager.DomainObject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BolgSytemManager.Domain.Base
{
    public partial interface IBaseRepository<TEntity> where TEntity : AggregateRoot
    {
        #region Properties 属性

        IQueryable<TEntity> Entites { get; }

        DbContext db { get; set; }

        #endregion

        #region Public Methods 公共方法

        TEntity Add(TEntity entity);

        int Add(IEnumerable<TEntity> entities);

        int Delete(object id);

        int Delete(TEntity entity);

        int Delete(Expression<Func<TEntity, bool>> express);

        int Delete(IEnumerable<TEntity> entities);

        int Update(TEntity entity);

        TEntity GetByKey(object key);

        IQueryable<TEntity> LoadEnities(Expression<Func<TEntity, bool>> express);

        IQueryable<TEntity> LoadPageEnities<S>(int PageIndex, int PageSize, out int TotalCount, Expression<Func<TEntity, bool>> WhereLamda, Expression<Func<TEntity, S>> OrderLamda = null, bool Asc = true);

         IQueryable<DTO> LoadEntities<DTO>(Expression<Func<TEntity, bool>> whereLambda) where DTO : BaseObject;

        #endregion
    }
}
