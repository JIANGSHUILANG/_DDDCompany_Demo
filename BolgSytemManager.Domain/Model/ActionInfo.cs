using BolgSytemManager.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace BolgSytemManager.Domain.Model
{
    public partial class ActionInfo : AggregateRoot
    {
        public ActionInfo()
        {
            this.UserInfos = new List<UserInfo>();
            this.Roles = new List<Role>();
        }
        //public int ID { get; set; }
        public string ActionInfoName { get; set; }
        public string Url { get; set; }
        public string HttpMethod { get; set; }
        public string Remark { get; set; }
        public short DelFalg { get; set; }
        public int shot { get; set; }
        public string content { get; set; }
        public Nullable<System.DateTime> SubTime { get; set; }
        public bool IsMenu { get; set; }
        public virtual ICollection<UserInfo> UserInfos { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual Menu Menu { get; set; }

    }
}
