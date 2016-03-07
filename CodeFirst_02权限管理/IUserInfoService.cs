using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_02权限管理
{
    public partial interface IUserInfoService : IBaseService<UserInfo>
    { }

    public partial class UserInfoService : BaseService<UserInfo>, IUserInfoService
    { }

}
