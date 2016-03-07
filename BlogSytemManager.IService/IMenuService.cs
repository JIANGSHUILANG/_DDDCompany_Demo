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
    public partial interface IMenuService : IApplicationServiceContract
    {
        [OperationContract]//[FaultContract(typeof(FaultData))] //[ApplyProxyDataContractResolver]
        MenuObject[] GetAllMenu();

        [OperationContract]
        MenuObject GetMenuById(object id);

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
        //MenuObject[] GetAllMenuPageOfItems(int pageIndex, int pageSize, XElement wherelamda, XElement orderbylamda = null);

        [OperationContract]
        MenuObjectPageOfItems GetMenupageOfitems(int pageIndex, int pageSize, MenuObjectPageOfItems pageofitems);

        [OperationContract]
        bool DeleteMenuById(object id);

        [OperationContract]
        bool DeleteMenus(string[] ids);

        [OperationContract]
        bool UpdateMenu(MenuObject obj);

        [OperationContract]
        bool UpdateMenus(MenuObject[] objs);

        [OperationContract]
        MenuObject CreateMenu(MenuObject obj);
    }
}
