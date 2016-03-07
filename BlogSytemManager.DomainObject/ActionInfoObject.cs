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



    [DataContract(IsReference = true)] //IsReference = true 操作是对象序列化时循环依赖引用解决的方法
    public class ActionInfoObject : BaseObject
    {
        [DataMemberAttribute()]
        public int ID { get; set; }
        [DataMemberAttribute()]
        public string ActionInfoName { get; set; }
        [DataMemberAttribute()]
        public string Url { get; set; }
        [DataMemberAttribute()]
        public string HttpMethod { get; set; }
        [DataMemberAttribute()]
        public int shot { get; set; }
        [DataMemberAttribute()]
        public string content { get; set; }
        [DataMemberAttribute()]
        public string Remark { get; set; }
        [DataMemberAttribute()]
        public short DelFalg { get; set; }
        [DataMemberAttribute()]//WCF 中 DTO 中的DateTime类型要使用DateTime? 类型
        public DateTime? SubTime { get; set; }

        [DataMemberAttribute()]
        public bool IsMenu { get; set; }

        [DataMemberAttribute()] //[DataMemberAttribute()]  //加了这个特么为毛IIS报错
        public UserInfoObjectList UserInfos { get; set; }

        [DataMemberAttribute()] //[DataMemberAttribute()]
        public RoleObjectList Roles { get; set; }

        [DataMemberAttribute()]
        public MenuObject Menu { get; set; }
    }
    public class ActionInfoObjectList : List<ActionInfoObject> { }

    [DataContract(IsReference = true)]
    public class ActionInfoObjectPageOfItems : BaseObjectPageOfItems
    {
        [DataMemberAttribute()]
        public ActionInfoObjectList ActionInfoObjectLists { get; set; }
    }
}
