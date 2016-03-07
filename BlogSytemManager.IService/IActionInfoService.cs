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
    public partial interface IActionInfoService : IApplicationServiceContract
    {
        [OperationContract]//[FaultContract(typeof(FaultData))] //[ApplyProxyDataContractResolver]
        ActionInfoObject[] GetAllActionInfo();

        [OperationContract]
        ActionInfoObject GetActionInfoById(object id);

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
        //ActionInfoObject[] GetAllActionInfoPageOfItems(int pageIndex, int pageSize, XElement wherelamda, XElement orderbylamda = null);

        [OperationContract]
        ActionInfoObjectPageOfItems GetActionInfopageOfitems(int pageIndex, int pageSize, ActionInfoObjectPageOfItems pageofitems);

        [OperationContract]
        bool DeleteActionInfoById(object id);

        [OperationContract]
        bool DeleteActionInfos(string[] ids);

        [OperationContract]
        bool UpdateActionInfo(ActionInfoObject obj);

        [OperationContract]
        bool UpdateActionInfos(ActionInfoObject[] objs);

        [OperationContract]
        ActionInfoObject CreateActionInfo(ActionInfoObject obj);

    }
}
