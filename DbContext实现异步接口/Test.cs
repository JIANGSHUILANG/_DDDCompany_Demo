using CodeFirst_01配置各种关系;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DbContextRepository去实现异步接口
{
    class Test
    {
        static void Main()
        {

        }
    }

    public interface IOrderableRepository<TEntity>
        where TEntity : class
    { }

    public interface IUnitOfWork
    {
        DbContext _db { get; set; }

        Task<int> SaveChangesAsync();
    }
    public class UnitOfWork : IUnitOfWork
    {

        public DbContext _db
        {
            get
            {
                return new CodeFirst_02Context();
            }
            set
            {
                _db = value;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _db.SaveChangesAsync();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)//捕获实体验证异常
            {

            }
            catch (OptimisticConcurrencyException)
            {

            }
            catch (Exception ex) //所有异常
            {

            }
            return default(int);
        }
    }

    public interface IOrderable<TEntity>
        where TEntity : class
    { }

    public interface ISpecification<TEntity>
        where TEntity : class
    { }

    public interface IRepositoryAsnc<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// 设定数据库上下文，一般由架构注入
        /// </summary>
        /// <param name="unitofwork"></param>
        void SetDbContext(IUnitOfWork unitofwork);

        /// <summary>
        /// 添加实体并提交到数据服务器
        /// </summary>
        /// <param name="item">Item to add to repository</param>
        Task Insert(TEntity item);

        /// <summary>
        /// 移除实体并提交到数据服务器
        /// 如果表存在约束，需要先操作子表信息
        /// </summary>
        /// <param name="item">Item to delete</param>
        Task Delete(TEntity item);

        /// <summary>
        /// 修改实体并提交到数据服务器
        /// </summary>
        /// <param name="item"></param>
        Task Update(TEntity item);

        /// <summary>
        /// 得到指定的实体集合（延时结果集）
        /// Get all elements of type {T} in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        IQueryable<TEntity> GetModel();

        /// <summary>
        /// 根据主键得到实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Find(params object[] id);
    }

    /// <summary>
    /// 异步操作
    /// 扩展Repository操作规范
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IExtensionRepositoryAsync<TEntity> : IRepositoryAsnc<TEntity>, IOrderableRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// 添加集合[集合数目不大时用此方法，超大集合使用BulkInsert]
        /// </summary>
        /// <param name="item"></param>
        Task Insert(IEnumerable<TEntity> item);

        /// <summary>
        /// 修改集合[集合数目不大时用此方法，超大集合使用BulkUpdate]
        /// </summary>
        /// <param name="item"></param>
        Task Update(IEnumerable<TEntity> item);

        /// <summary>
        /// 操作集合[集合数目不大时用此方法，超大集合使用批量操作]
        /// </summary>
        /// <param name="item"></param>
        Task Delete(IEnumerable<TEntity> item);

        /// <summary>
        /// 根据指定lambda表达式,得到延时结果集
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetModel(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据指定lambda表达式,得到第一个实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 批量添加，添加之前可以去除自增属性,默认不去除
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isRemoveIdentity"></param>
        Task BulkInsert(IEnumerable<TEntity> item, bool isRemoveIdentity);

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="item"></param>
        Task BulkInsert(IEnumerable<TEntity> item);

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="item"></param>
        Task BulkUpdate(IEnumerable<TEntity> item, params string[] fieldParams);

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="item"></param>
        Task BulkDelete(IEnumerable<TEntity> item);

        /// <summary>
        /// 保存之后
        /// </summary>
        event Action<SavedEventArgs> AfterSaved;

        /// <summary>
        /// 保存之前
        /// </summary>
        event Action<SavedEventArgs> BeforeSaved;
    }

    /// <summary>
    /// EF底层构架，关于规约功能的仓储接口
    /// </summary>
    public interface ISpecificationRepositoryAsnc<TEntity> : IExtensionRepositoryAsync<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// 根据指定规约,得到延时结果集
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetModel(ISpecification<TEntity> specification);

        /// <summary>
        /// 根据指定规约,得到第一个实体
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        TEntity Find(ISpecification<TEntity> specification);

        /// <summary>
        /// 带排序功能的，根据指定规约，得到结果集
        /// </summary>
        /// <param name="orderBy"></param>
        /// <param name="specification"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetModel(Action<IOrderable<TEntity>> orderBy, ISpecification<TEntity> specification);

    }

    public class SavedEventArgs
    {
        public SavedEventArgs()
        {

        }
        public SavedEventArgs(object item, SaveAction action)
        {

        }

    }

    public enum SaveAction
    {
        Insert,
        Delete,
        Update
    }


    //引用—CodeFirst_01配置各种关系 
    public class DbContextRepository<TEntity> : IExtensionRepositoryAsync<TEntity>
         where TEntity : class
    {
        public IUnitOfWork UnitOfWork { get { return new UnitOfWork(); } set { UnitOfWork = value; } }


        #region IExtensionRepositoryAsync 接口实现

        public async Task Insert(IEnumerable<TEntity> item)
        {
            item.ToList().ForEach(c =>
            {
                UnitOfWork._db.Entry<TEntity>(c);
                UnitOfWork._db.Set<TEntity>().Add(c);
            });
            await UnitOfWork._db.SaveChangesAsync();
        }

        public async Task Update(IEnumerable<TEntity> item)
        {
            item.ToList().ForEach(c =>
            {
                UnitOfWork._db.Set<TEntity>().Attach(c);
                UnitOfWork._db.Entry(c).State = EntityState.Modified;
            });
            try
            {
                await UnitOfWork._db.SaveChangesAsync();
            }
            catch (OptimisticConcurrencyException)//并发冲突异常
            {

            }
        }

        public async Task Delete(IEnumerable<TEntity> item)
        {
            item.ToList().ForEach(i =>
            {
                UnitOfWork._db.Set<TEntity>().Attach(i);
                UnitOfWork._db.Set<TEntity>().Remove(i);
            });
            await UnitOfWork._db.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetModel(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task BulkInsert(IEnumerable<TEntity> item, bool isRemoveIdentity)
        {
            await Task.Run(() =>
            {
                return this.BulkInsert(item, isRemoveIdentity);
            });
        }

        public async Task BulkInsert(IEnumerable<TEntity> item)
        {
            await Task.Run(() =>
            {
                return this.BulkInsert(item);
            });
        }

        public async Task BulkUpdate(IEnumerable<TEntity> item, params string[] fieldParams)
        {
            await Task.Run(() =>
            {
                return this.BulkUpdate(item);
            });
        }

        public async Task BulkDelete(IEnumerable<TEntity> item)
        {
            await Task.Run(() =>
            {
                return this.BulkDelete(item);
            });
        }

        #endregion

        public event Action<SavedEventArgs> AfterSaved;

        public event Action<SavedEventArgs> BeforeSaved;


        #region IRepositoryAsnc 接口实现

        public void SetDbContext(IUnitOfWork unitofwork)
        {
            throw new NotImplementedException();
        }
        public async Task Insert(TEntity item)
        {
            BeforeSaved(new SavedEventArgs(item, SaveAction.Insert));

            UnitOfWork._db.Entry<TEntity>(item);
            UnitOfWork._db.Set<TEntity>().Add(item);
            await UnitOfWork.SaveChangesAsync();

            AfterSaved(new SavedEventArgs(item, SaveAction.Insert));
        }

        public async Task Delete(TEntity item)
        {
            BeforeSaved(new SavedEventArgs(item, SaveAction.Delete));
            UnitOfWork._db.Set<TEntity>().Attach(item);
            UnitOfWork._db.Set<TEntity>().Remove(item);
            await UnitOfWork.SaveChangesAsync();
            AfterSaved(new SavedEventArgs(item, SaveAction.Delete));
        }

        public async Task Update(TEntity item)
        {
            BeforeSaved(new SavedEventArgs(item, SaveAction.Update));
            UnitOfWork._db.Set<TEntity>().Attach(item);
            UnitOfWork._db.Entry(item).State = EntityState.Modified;
            try
            {
                await UnitOfWork.SaveChangesAsync();
            }
            catch (OptimisticConcurrencyException)//并发冲突异常
            {

            }

            AfterSaved(new SavedEventArgs(item, SaveAction.Update));
        }

        public IQueryable<TEntity> GetModel()
        {
            throw new NotImplementedException();
        }

        public TEntity Find(params object[] id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

}
