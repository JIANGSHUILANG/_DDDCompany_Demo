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
    public class MenuChildenObject : BaseObject
    {
        [DataMember]
        public int ID { get; set; }
        //此菜单的上一级ID
        [DataMember]
        public int Parent_ID { get; set; }
        [DataMember]
        public string MenuChildenName { get; set; }
        [DataMember]
        public int Menu_ID { get; set; }
        [DataMemberAttribute()]
        public string Url { get; set; }
        [DataMemberAttribute()]
        public int shot { get; set; }
        [DataMemberAttribute()]
        public string content { get; set; }
        [DataMember]
        public DateTime? CreateTime { get; set; }
        [DataMember]
        public DateTime? UpdateTime { get; set; }
        [DataMember]
        public short DelFlag { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public MenuObject Menu { get; set; }
    }

    public class MenuChildenObjectList : List<MenuChildenObject>
    {

    }

    [DataContract(IsReference = true)]
    public class MenuChildenObjectPageOfItems : BaseObjectPageOfItems
    {
        [DataMemberAttribute()]
        public MenuChildenObjectList MenuChildenObjectLists { get; set; }
    }
}
