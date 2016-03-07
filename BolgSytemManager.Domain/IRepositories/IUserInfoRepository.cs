using BolgSytemManager.Domain.Base;
using BolgSytemManager.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolgSytemManager.Domain.IRepositories
{
    public partial interface IUserInfoRepository : IBaseRepository<UserInfo>
    {
        bool ForUserInfoAutor(string CURDS, string MENUS, string ACTIONS, int RoleId, int UserID);
        bool IsexsitsProcedure(string procedurename);
        bool IsexsitsFunction(string functionname);
    }
}
