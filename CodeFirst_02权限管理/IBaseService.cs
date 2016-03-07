using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_02权限管理
{
    public interface IBaseService<T> where T : AggregateRoot
    {

        #region 查询方法

        /// <summary>
        /// 查询，根据条件查询
        /// </summary>
        /// <param name="whereLambda">条件</param>
        /// <returns></returns>
        IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 查询分页，返回总页数
        /// </summary>
        /// <typeparam name="s">排序字段的类型<!--orderbyLambad使用--></typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页尺寸</param>
        /// <param name="totalCount">总页数</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="orderbyLambad">排序条件</param>
        /// <param name="isAsc">正序:true  倒序:false</param>
        /// <returns></returns>
        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambad, bool isAsc);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="s">排序字段</typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页尺寸</param>
        /// <param name="whereLambda">条件</param>
        /// <param name="orderbyLambad">排序条件</param>
        /// <param name="isAsc">正序:true  倒序:false</param>
        /// <returns></returns>
        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambad, bool isAsc);


        #endregion

        bool DeleteEntity(T entity);
        bool UpdateEntity(T entity);
        T AddEntity(T entity);
    }

    /// <summary>
    /// 封装的是业务层中公共的代码（CURD）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseService<T> : IBaseService<T> where T : AggregateRoot
    {

        #region EF

        private AfterManageContext _db
        {
            get
            {
                #region 保证EF上下文线程内唯一 ..

                object dbcontext = (DbContext)CallContext.GetData("dbContext");
                if (dbcontext == null)
                {
                    dbcontext = new AfterManageContext();
                    CallContext.SetData("dbContext", dbcontext);
                }
                return (AfterManageContext)dbcontext;
                #endregion
            }
        }

        #endregion

        #region 查询方法

        /// <summary>
        /// 查询，根据条件查询所有
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return _db.Set<T>().Where<T>(whereLambda);
        }

        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambad, bool isAsc)
        {
            var temp = _db.Set<T>().Where<T>(whereLambda);
            totalCount = temp.Count();
            if (isAsc)//升序
            {
                temp = temp.OrderBy<T, s>(orderbyLambad).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, s>(orderbyLambad).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;
        }

        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambad, bool isAsc)
        {
            var temp = _db.Set<T>().Where<T>(whereLambda);

            if (isAsc)//升序
            {
                temp = temp.OrderBy<T, s>(orderbyLambad).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, s>(orderbyLambad).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;
        }

        #endregion

        public bool DeleteEntity(T entity)
        {
            _db.Entry<T>(entity).State = System.Data.EntityState.Deleted;
            return _db.SaveChanges() > 0;
        }

        public bool UpdateEntity(T entity)
        {
            _db.Entry<T>(entity).State = System.Data.EntityState.Modified;
            return _db.SaveChanges() > 0;
        }

        public T AddEntity(T entity)
        {
            _db.Set<T>().Add(entity);
            return _db.SaveChanges() > 0 ? entity : null;
        }
    }
}
