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
    public class RoleObject : BaseObject
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public short DelFlag { get; set; }
        [DataMember]
        public short RoleType { get; set; }
        [DataMember]//WCF 中 DTO 中的DateTime类型要使用DateTime? 类型
        public DateTime? SubTime { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMemberAttribute()]
        public int shot { get; set; }
        [DataMemberAttribute()]
        public string content { get; set; }
        [DataMemberAttribute()]   //加了这个特么为毛IIS报错
        public UserInfoObjectList UserInfos { get; set; }
        [DataMemberAttribute()]
        public ActionInfoObjectList ActionInfos { get; set; }
        [DataMemberAttribute()]
        public MenuObjectList Menus { get; set; }
        [DataMemberAttribute()]  //CURD权限
        public PermissionObjectList Permission { get; set; }
    }

    public class RoleObjectList : List<RoleObject>
    {

    }

    [DataContract(IsReference = true)]
    public class RoleObjectPageOfItems:BaseObjectPageOfItems
    {
        [DataMemberAttribute()]
        public RoleObjectList RoleObjectLists { get; set; }
    }
}
