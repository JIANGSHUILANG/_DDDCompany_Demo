using DDDCompany.Domain.BaseModel;
using DDDCompany.Domain.IRepositories.Base;
using DDDCompany.Infrastructure.MEF;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDCompany.Repository.UnitOfWork
{
    /// <summary>
    /// 工作单元实现类
    /// </summary>
    [Export(typeof(IEFUnitOfWork))]  //引用 System.ComponentModel.Composition.dll
    public class EFUnitOfWork : IEFUnitOfWork
    {
        #region IEFUnitOfWork 实现

        public DbContext context
        {
            get { return EFContext; }
        }

        [Import(typeof(DbContext))]
        public DbContext EFContext { get; set; }
        #endregion

        public EFUnitOfWork()
        {
            // 注册 MEF
            Register.regisgter().ComposeParts(this);
        }

        #region IUnitOfWorkRepositoryContext 实现


        public void RegisterNew<TEntity>(TEntity obj) where TEntity : AggregateRoot
        {
            if (context.Entry(obj).State == System.Data.EntityState.Detached)
            {
                context.Entry(obj).State = System.Data.EntityState.Added;
            }
            IsCommitted = false;
        }

        public void RegisterModified<TEntity>(TEntity obj) where TEntity : AggregateRoot
        {
            if (context.Entry(obj).State == System.Data.EntityState.Detached)
            {
                context.Set<TEntity>().Attach(obj);
            }
            context.Entry(obj).State = System.Data.EntityState.Modified;
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
            catch(Exception ex)
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

        public void Dispose()
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
