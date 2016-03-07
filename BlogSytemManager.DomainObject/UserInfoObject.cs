using BlogSytemManager.DomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlogSytemManager.DomainObject
{
    /*
     接收对 http://localhost:7911/UserInfoService.svc 的 HTTP 响应时发生错误。
     * 这可能是由于服务终结点绑定未使用 HTTP 协议造成的。这还可能是由于服务器中止了 HTTP 请求上下文(可能由于服务关闭)所致。
     * 有关详细信息，请参见服务器日志
     * 
     * 解决以上错误：IsReference = true
     */
    [DataContract(IsReference = true)]
    public class UserInfoObject : BaseObject
    {
        [DataMemberAttribute()]
        public int ID { get; set; }
        [DataMemberAttribute()]
        public string UserName { get; set; }
        [DataMemberAttribute()]
        public string UserPass { get; set; }
        [DataMemberAttribute()] //WCF 中 DTO 中的DateTime类型要使用DateTime? 类型
        public DateTime? RegTime { get; set; }
        [DataMemberAttribute()]
        public string Email { get; set; }
        [DataMemberAttribute()]
        public int shot { get; set; }
        [DataMemberAttribute()]
        public string content { get; set; }
        [DataMemberAttribute()]
        public string address { get; set; }
        [DataMemberAttribute()]
        public int city1 { get; set; }
        [DataMemberAttribute()]
        public int city2 { get; set; }
        [DataMemberAttribute()]
        public int city3 { get; set; }
        [DataMemberAttribute()]
        public string cell { get; set; }
        [DataMemberAttribute()]
        public int status { get; set; }  // 1：新增管理员  2：审核未通过管理员  3：审核通过的管理员
        [DataMemberAttribute()]
        public string QQ { get; set; }
        [DataMemberAttribute()]
        public string weibo { get; set; }
        [DataMemberAttribute()]
        public string head_image { get; set; }


        [DataMemberAttribute()]  //加了这个特么为毛IIS报错
        public RoleObjectList Roles { get; set; }
        [DataMemberAttribute()]
        public ActionInfoObjectList ActionInfos { get; set; }
        [DataMemberAttribute()]  //用户有多个菜单
        public MenuObjectList Menus { get; set; }

        [DataMemberAttribute()]  //CURD权限
        public PermissionObjectList Permission { get; set; }
    }


    public class UserInfoObjectList : List<UserInfoObject>
    {

    }
    [DataContract(IsReference = true)]
    public class UserInfoObjectPageOfItems : BaseObjectPageOfItems
    {
        [DataMemberAttribute()]
        public UserInfoObjectList UserInfoObjectLists { get; set; }
    }
    [DataContract(IsReference = true)]
    public class BaseObjectPageOfItems
    {
        /// <summary>
        /// 分页后的个数
        /// </summary>
        [DataMemberAttribute()]
        public int TotalCount { get; set; }
        [DataMemberAttribute()]
        public int PageIndex { get; set; }
        [DataMemberAttribute()]
        public int PageSize { get; set; }
        [DataMemberAttribute()]
        public int AllCount { get; set; }
    }
}
