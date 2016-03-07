using BlogSytemManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BlogSytemManager.IService
{
    /// <summary>
    /// 表示与“会员”相关的应用层服务契约。
    /// </summary>
    [ServiceContract(Namespace = "http://www.CC.com")]
    public interface I_AggregatUserAuthorService : IApplicationServiceContract
    {

        [OperationContract]
        void PublicSearch(string controllname, string wherename, string wherevalue);


        [OperationContract] //为用户分配权限
        bool ForUserInfoAuthor(int userinfo_ID, int[] ActionInfos, int[] Menu, int[] Permission, int role);

    }
}
