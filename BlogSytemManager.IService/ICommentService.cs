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
    public partial interface ICommentService : IApplicationServiceContract
    {
      
    }
}
