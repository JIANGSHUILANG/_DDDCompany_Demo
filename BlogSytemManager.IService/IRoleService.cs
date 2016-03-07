using BlogSytemManager.DomainObject;
using BlogSytemManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BlogSytemManager.IService
{
    [ServiceContract(Namespace = "http://www.CC.com")]
    public partial interface IRoleService : IApplicationServiceContract
    {
        [OperationContract]//[FaultContract(typeof(FaultData))] //[ApplyProxyDataContractResolver]
        RoleObject[] GetAllRole();

        [OperationContract]
        RoleObject GetRoleById(object id);

        /// <summary>
        /// WCF不支持Expression 表达式，用 XElement 表示
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="wherelamda"></param>
        /// <param name="orderbylamda"></param>
        /// <returns></returns>
        //[OperationContract]
        //RoleObject[] GetAllRolePageOfItems(int pageIndex, int pageSize, XElement wherelamda, XElement orderbylamda = null);

        [OperationContract]
        RoleObjectPageOfItems GetRolepageOfitems(int pageIndex, int pageSize, RoleObjectPageOfItems pageofitems);

        [OperationContract]
        bool DeleteRoleById(object id);

        [OperationContract]
        bool DeleteRoles(string[] ids);

        [OperationContract]
        bool UpdateRole(RoleObject obj);

        [OperationContract]
        bool UpdateRoles(RoleObject[] objs);

        [OperationContract]
        RoleObject CreateRole(RoleObject obj);
    }
}
