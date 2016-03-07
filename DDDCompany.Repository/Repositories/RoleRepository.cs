using DDDCompany.Domain.IRepositories;
using DDDCompany.Domain.IRepositories.Base;
using DDDCompany.Domain.EFModel;
using DDDCompany.Repository.Repositories.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDCompany.Repository.Repositories
{
    /// <summary>
    /// 角色这个聚合根的仓储接口
    /// </summary>
    [Export(typeof(IRoleRepository))]
    public class RoleRepository : EFBaseRepository<Role>, IRoleRepository
    {
    }
}
