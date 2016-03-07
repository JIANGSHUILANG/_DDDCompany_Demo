using BolgSytemManager.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolgSytemManager.Domain.Model
{
    public partial class UserInfo : AggregateRoot
    {
        public UserInfo()
        {
            this.Roles = new List<Role>();
            this.ActionInfos = new List<ActionInfo>();
            this.Menus = new List<Menu>();
            this.Permissions = new List<Permission>();
        }
        //public int ID { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string QQ { get; set; }
        public string weibo { get; set; }
        //头像
        public string head_image { get; set; }
        public Nullable<System.DateTime> RegTime { get; set; }
        // 1：新增管理员  2：审核未通过管理员  3：审核通过的管理员
        public int status { get; set; }
        public string Email { get; set; }
        public int shot { get; set; }
        public string cell { get; set; }
        public string address { get; set; }
        public int city1 { get; set; }
        public int city2 { get; set; }
        public int city3 { get; set; }
        public string content { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<ActionInfo> ActionInfos { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
