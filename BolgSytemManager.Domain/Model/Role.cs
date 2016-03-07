using BolgSytemManager.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolgSytemManager.Domain.Model
{
    public partial class Role : AggregateRoot
    {
        public Role()
        {
            this.ActionInfos = new List<ActionInfo>();
            this.UserInfos = new List<UserInfo>();
            this.Menus = new List<Menu>();
            this.Permissions = new List<Permission>();
        }
        //public int ID { get; set; }
        public string RoleName { get; set; }
        public short DelFlag { get; set; }
        public short RoleType { get; set; }
        public int shot { get; set; }
        public string content { get; set; }
        public Nullable<System.DateTime> SubTime { get; set; }
        public string Remark { get; set; }
        public virtual ICollection<UserInfo> UserInfos { get; set; }
        public virtual ICollection<ActionInfo> ActionInfos { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
