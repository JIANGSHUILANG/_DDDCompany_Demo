using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlogSytemManager.DomainObject
{
    [DataContract(IsReference = true)]
    public class PermissionObject : BaseObject
    {

        [DataMemberAttribute()]
        public int ID { get; set; }
        [DataMemberAttribute()]
        public string PermissionName { get; set; }
        [DataMemberAttribute()]
        public int shot { get; set; }
        [DataMemberAttribute()]
        public string content { get; set; }
        [DataMemberAttribute()]
        public virtual RoleObjectList Roles { get; set; }
        [DataMemberAttribute()]
        public virtual UserInfoObjectList UserInfos { get; set; }
    }

    public class PermissionObjectList : List<PermissionObject>
    {

    }

    [DataContract(IsReference = true)]
    public class PermissionObjectPageOfItems : BaseObjectPageOfItems
    {
        [DataMemberAttribute()]
        public PermissionObjectList PermissionObjectLists { get; set; }
    }
}
