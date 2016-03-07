using BlogSytemManager.DomainObject;
using BlogSytemManager.DomainObject._PageOfItems;
using BlogSytemManager.Infrastructure;
using BlogSytemManager.IService.Self;
using BolgSytemManager.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlogSytemManager.IService
{
    /// <summary>
    /// 表示与“会员”相关的应用层服务契约。
    /// </summary>
    [ServiceContract(Namespace = "http://www.CC.com")]
    public partial interface IMenuChildenService : IApplicationServiceContract
    {
        [OperationContract]//[FaultContract(typeof(FaultData))] //[ApplyProxyDataContractResolver]
        MenuChildenObject[] GetAllMenuChilden();

        [OperationContract]
        MenuChildenObject GetMenuChildenById(object id);

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
        //MenuChildenObject[] GetAllMenuChildenPageOfItems(int pageIndex, int pageSize, XElement wherelamda, XElement orderbylamda = null);

        [OperationContract]
        MenuChildenObjectPageOfItems GetMenuChildenpageOfitems(int pageIndex, int pageSize, MenuChildenObjectPageOfItems pageofitems);

        [OperationContract]
        bool DeleteMenuChildenById(object id);

        [OperationContract]
        bool DeleteMenuChildens(string[] ids);

        [OperationContract]
        bool UpdateMenuChilden(MenuChildenObject obj);

        [OperationContract]
        bool UpdateMenuChildens(MenuChildenObject[] objs);

        [OperationContract]
        MenuChildenObject CreateMenuChilden(MenuChildenObject obj);

    }
}
