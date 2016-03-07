using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolgSytemManager.Domain.Base
{
    /// <summary>
    /// 工作单元基类接口
    /// </summary>
    public interface IUnitOfWork
    {
        bool IsCommitted { get; set; }

        int Commit();

        void Rollback();
    }
}
