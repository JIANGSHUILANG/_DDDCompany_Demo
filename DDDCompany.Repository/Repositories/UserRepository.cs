using DDDCompany.Domain.EFModel;
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
    /// 用户这个聚合根的仓储接口
    /// </summary>
    [Export(typeof(IUserRepository))]
    public class UserRepository : EFBaseRepository<DDDCompany.Domain.EFModel.User>, IUserRepository
    {
        public IQueryable<DDDCompany.Domain.EFModel.User> GetUsers_Role(int roletype)
        {
            var users = UnitOfWork.context.Set<DDDCompany.Domain.EFModel.User>();

            var role = UnitOfWork.context.Set<DDDCompany.Domain.EFModel.Role>();

            //Linq Select 方法一：
            //var result = from u in users
            //             from r in role
            //             where u.Role_ID == r.ID && u.Role_ID == roletype
            //             select u;
            //return result;

            //多表连接查询
            var results = from u in users
                          join r in role
                          on u.Role_ID equals r.ID
                          where u.Role_ID == roletype
                          select u;

            return results;

            //多表连接查询
            //from da in dc.q1
            //join du in dc.q2
            //on da.danhao equals du.danhao
            //where da.hetong == "XXXX"
            //select new { du.color1,  da.danhao, da.riqi, du.zhongliang, du.beizhu }).Distinct();


        }
    }

}
