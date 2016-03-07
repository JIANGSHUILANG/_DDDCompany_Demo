using BolgSytemManager.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolgSytemManager.Domain.Model
{
   public class Permission:AggregateRoot
    {
       public Permission()
       {
           this.Roles = new List<Role>();
           this.UserInfos = new List<UserInfo>();
       }
        //public int ID { get; set; }
        public string PermissionName { get; set; }
        public int shot { get; set; }
        public string content { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<UserInfo> UserInfos { get; set; }
    }
}
