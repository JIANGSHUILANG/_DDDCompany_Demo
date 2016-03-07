using DDDCompany.Domain.EFModel;
using DDDCompany.Domain.IRepositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDCompany.Domain.IRepositories
{
    /// <summary>
    /// 用户这个聚合根的仓储接口
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <returns></returns>
        IQueryable<User> GetUsers_Role(int roletype);
    }


}
