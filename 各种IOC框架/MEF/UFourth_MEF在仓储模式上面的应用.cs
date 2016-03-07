using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 各种IOC框架.MEF
{
    //仓储模式就是对数据访问层（或者叫数据映射层）做了一层包装，每一次前端需要查询什么数据或者提交什么数据的时候，都是通过仓储对象Repository去操作的，前端基本上感觉不到数据访问层的存在。
    class UFourth_MEF在仓储模式上面的应用
    {
        static void Main(string[] args)
        {

        }
    }

    public interface IRepository<T> where T : BaseEntity
    {
        T Save(T entity);
    }

    [Export(typeof(IRepository<BaseEntity>))]
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public Repository()
        {
            //注册MEF  , 将部件（part） 和宿主程序添加到组合容器 !!
            Register.register().ComposeParts(this);
        }
        //工作单元
        [Import]
        protected IUnitOfWork context { get; set; }

        private IDbSet<T> _entites;  //  IDbSet    引入:EntityFramework.dll

        public virtual T Save(T entity)
        {
            if (entity == null)
                throw new ArgumentException("entity is null ......");
            context.Save<T>(entity);
            return entity;
        }
    }

    //BaseEntity是一个EF实体的公共基类，定义EF实体必须要遵循的约束。
    public class BaseEntity  // 聚合跟 ???
    {

    }

    public interface IUnitOfWork
    {
        int Commit();

        void Rollback();

        void Save<T>(T entity) where T : BaseEntity;
    }
    /// <summary>
    /// 单元操作实现
    /// </summary>
    public abstract class UnitOfWorkContextBase : IUnitOfWork
    {
        [ImportMany]
        protected abstract IEnumerable<DbContext> Contexts { get; }

        protected abstract DbContext Cur_context { get; set; }
        /// <summary>
        /// 获取 当前单元操作是否已被提交   只读
        /// </summary>
        public bool IsCommitted { get; private set; }

        public UnitOfWorkContextBase()
        {
            Register.register().ComposeParts(this);

            if (Contexts.Count() <= 0)
                throw new Exception();

            Cur_context = Contexts.FirstOrDefault();
        }

        public int Commit()
        {
            if (IsCommitted)
                return 0;
            try
            {
                int result = Cur_context.SaveChanges();
                IsCommitted = true;
                return result;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException is SqlException)
                {
                    //SqlException sqlEx = e.InnerException.InnerException as SqlException;
                    //string msg = DataHelper.GetSqlExceptionMessage(sqlEx.Number);
                    //throw PublicHelper.ThrowDataAccessException("提交数据更新时发生异常：" + msg, sqlEx);
                }
                throw;
            }
        }

        public void Rollback()
        {
            IsCommitted = false;
        }

        public void Save<T>(T entity) where T : BaseEntity
        {
            Cur_context.SaveChanges();
        }
    }


    public static class Register
    {
        //宿主MEF组合部件
        public static CompositionContainer register()
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer();
            return container;
        }
    }
}
