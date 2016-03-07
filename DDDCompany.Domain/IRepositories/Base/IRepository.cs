using DDDCompany.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDDCompany.Domain.IRepositories.Base
{


    /// <summary>
    /// 仓储接口，定义公共的泛型CRUD
    /// </summary>
    /// <typeparam name="TEntity">泛型聚合根，因为在DDD里面仓储只能对聚合根做操作</typeparam>
    public interface IRepository<TEntity> where TEntity : AggregateRoot
    {
        #region Properties 属性

        IQueryable<TEntity> Entites { get; }

        #endregion

        #region Public Methods 公共方法

        int Add(TEntity entity);

        int Add(IEnumerable<TEntity> entities);

        int Delete(object id);

        int Delete(TEntity entity);

        int Delete(Expression<Func<TEntity, bool>> express);

        int Delete(IEnumerable<TEntity> entities);

        int Update(TEntity entity);

        TEntity GetByKey(object key);

        IQueryable<TEntity> LoadEnities(Expression<Func<TEntity, bool>> express);

        IQueryable<TEntity> LoadPageEnities<S>(int PageIndex, int PageSize, out int TotalCount, Expression<Func<TEntity, bool>> WhereLamda, Expression<Func<TEntity, S>> OrderLamda = null, bool Asc = true);

        #endregion
    }
}
