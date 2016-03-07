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
    public partial interface IPermissionService : IApplicationServiceContract
    {
        [OperationContract]//[FaultContract(typeof(FaultData))] //[ApplyProxyDataContractResolver]
        PermissionObject[] GetAllPermission();

        [OperationContract]
        PermissionObject GetPermissionById(object id);

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
        //PermissionObject[] GetAllPermissionPageOfItems(int pageIndex, int pageSize, XElement wherelamda, XElement orderbylamda = null);

        [OperationContract]
        PermissionObjectPageOfItems GetPermissionpageOfitems(int pageIndex, int pageSize, PermissionObjectPageOfItems pageofitems);

        [OperationContract]
        bool DeletePermissionById(object id);

        [OperationContract]
        bool DeletePermissions(string[] ids);

        [OperationContract]
        bool UpdatePermission(PermissionObject obj);

        [OperationContract]
        bool UpdatePermissions(PermissionObject[] objs);

        [OperationContract]
        PermissionObject CreatePermission(PermissionObject obj);
    }
}
