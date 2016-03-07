using BolgSytemManager.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolgSytemManager.Domain.Model
{
    public class Menu : AggregateRoot
    {
        public Menu()
        {
            this.MenuChildens = new List<MenuChilden>();
            this.ActionInfos = new List<ActionInfo>();
            this.Roles = new List<Role>();
            this.UserInfos = new List<UserInfo>();
        }
        //public int ID { get; set; }
        public string MenuName { get; set; }
        public Nullable<DateTime> CreateTime { get; set; }
        public short DelFlag { get; set; }
        public string Url { get; set; }
        public string Remark { get; set; }
        public int shot { get; set; }
        public string content { get; set; }
        public Nullable<DateTime> UpdateTime { get; set; }
        public virtual ICollection<MenuChilden> MenuChildens { get; set; }
        public virtual ICollection<ActionInfo> ActionInfos { get; set; } //一个菜单包含多个方法 URL
        public virtual ICollection<UserInfo> UserInfos { get; set; }
        public virtual ICollection<Role> Roles { get; set; } 
    }
}
