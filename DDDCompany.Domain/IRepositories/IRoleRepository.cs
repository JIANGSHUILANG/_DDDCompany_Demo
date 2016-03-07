using DDDCompany.Domain.IRepositories.Base;
using DDDCompany.Domain.EFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDCompany.Domain.IRepositories
{
    /// <summary>
    /// 角色这个聚合根的仓储接口
    /// </summary>
    public interface IRoleRepository : IRepository<Role>
    {
    }
}
