using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlogSytemManager.DomainObject
{
    public class CommentObject : BaseObject
    {
        public int ID { get; set; }
        public string Content { get; set; }
        //评论人的姓名
        public string CommentName { get; set; }
        public string CommentHeadUrl { get; set; }
        public int Support { get; set; }
        //反对
        public int Oppose { get; set; }
        public Nullable<DateTime> CreateTime { get; set; }
    }
    public class CommentObjectList : List<CommentObject>
    {

    }

    public class CommentObjectPageOfItems : BaseObjectPageOfItems
    {
        [DataMemberAttribute()]
        public CommentObjectList CommentObjectLists { get; set; }
    }
}
