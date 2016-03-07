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
     接收对 http://localhost:7911/MenuService.svc 的 HTTP 响应时发生错误。
     * 这可能是由于服务终结点绑定未使用 HTTP 协议造成的。这还可能是由于服务器中止了 HTTP 请求上下文(可能由于服务关闭)所致。
     * 有关详细信息，请参见服务器日志
     * 
     * 解决以上错误：IsReference = true
     */
    [DataContract(IsReference = true)]
    public class MenuObject : BaseObject
    {
        [DataMemberAttribute()]
        public int ID { get; set; }
        [DataMemberAttribute()]
        public string MenuName { get; set; }
        [DataMemberAttribute()]
        public DateTime? CreateTime { get; set; }
        [DataMemberAttribute()]
        public short DelFlag { get; set; }
        [DataMemberAttribute()]
        public string Url { get; set; }
        [DataMemberAttribute()]
        public string Remark { get; set; }
        [DataMemberAttribute()]
        public int shot { get; set; }
        [DataMemberAttribute()]
        public string content { get; set; }
        [DataMemberAttribute()]
        public DateTime? UpdateTime { get; set; }
        [DataMemberAttribute()]
        public MenuChildenObjectList MenuChildens { get; set; }
        [DataMemberAttribute()]
        public ActionInfoObjectList ActionInfos { get; set; }
        [DataMemberAttribute()]
        public UserInfoObjectList UserInfos { get; set; }
        [DataMemberAttribute()]
        public RoleObjectList Roles { get; set; }
    }


    public class MenuObjectList : List<MenuObject>
    {

    }
    [DataContract(IsReference = true)]
    public class MenuObjectPageOfItems : BaseObjectPageOfItems
    {
        [DataMemberAttribute()]
        public MenuObjectList MenuObjectLists { get; set; }
    }
}
