using BlogSytemManager.Repository.EFContext;
using BolgSytemManager.Domain.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
namespace BlogSytemManager.Repository.UnitOfWork
{
    public class EFUnitOfWork : IEFUnitOfWork
    {
        //#region IEFUnitOfWork 实现

        //public DbContext context
        //{
        //    get { return EFContext; }
        //}

        //[Import(typeof(DbContext))]
        //public DbContext EFContext { get; set; }
        //#endregion

        //public EFUnitOfWork()
        //{
        //    // 注册 MEF
        //    Register.regisgter().ComposeParts(this);
        //}

        #region IEFUnitOfWork 实现

        public DbContext context
        {
            get { return EFContext; }
        }


        public DbContext EFContext
        {
            get
            {
                object dbcontext = (DbContext)CallContext.GetData("dbContext");
                if (dbcontext == null)
                {
                    dbcontext = new AfterManageContext();
                    CallContext.SetData("dbContext", dbcontext);
                }
                return (AfterManageContext)dbcontext;
            }
            set { EFContext = value; }
        }



        #endregion

        #region IUnitOfWorkRepositoryContext 实现


        public TEntity RegisterNew<TEntity>(TEntity obj) where TEntity : AggregateRoot
        {
            if (context.Entry(obj).State == System.Data.EntityState.Detached)
            {
                context.Entry(obj).State = System.Data.EntityState.Added;
            }

            IsCommitted = false;

            return obj;
        }

        public void RegisterModified<TEntity>(TEntity obj) where TEntity : AggregateRoot
        {
            //修改时ObjectStateManager 中已存在具有同一键的对象
            //var entry = m_dbContext.Entry(entity);
            //if (entry.State == EntityState.Detached)
            //{
            //var entityToUpdate = FindById(entity.Id);
            //EmitMapper.ObjectMapperManager.DefaultInstance.GetMapper<TEntity, TEntity>().Map(entity, entityToUpdate);
            //}


            //if (context.Entry(obj).State == System.Data.EntityState.Detached)
            //{
            //    context.Set<TEntity>().Attach(obj);
            //}
            //context.Entry(obj).State = System.Data.EntityState.Modified;
            //IsCommitted = false;
            
            var entry = context.Entry(obj);
            if (entry.State == System.Data.EntityState.Detached)
            {
                var updatemodel = context.Set<TEntity>().Find(obj.ID);
                var temp = EmitMapper.ObjectMapperManager.DefaultInstance.GetMapper<TEntity, TEntity>().Map(obj,
   updatemodel);
                context.Set<TEntity>().Attach(temp);
                context.Entry(temp).State = System.Data.EntityState.Modified;
            }

            IsCommitted = false;
        }

        public void RegisterDeleted<TEntity>(TEntity obj) where TEntity : AggregateRoot
        {
            context.Entry(obj).State = System.Data.EntityState.Deleted;
            IsCommitted = false;
        }
        #endregion

        #region IUnitOfWork 实现

        public bool IsCommitted { get; set; }


        public int Commit()
        {
            if (IsCommitted) return 0;

            try
            {
                int result = context.SaveChanges();
                IsCommitted = true;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Rollback()
        {
            IsCommitted = false;
        }

        #endregion

        #region IDisposable 实现

        public virtual void Dispose()
        {
            if (!IsCommitted)
            {
                Commit();
            }

            context.Dispose();
        }

        #endregion
    }
}
