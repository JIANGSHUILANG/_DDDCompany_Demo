using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst_03使用.Models
{
    public class ActionInfo_DTO
    {
        public int ID { get; set; }
        public string ActionInfoName { get; set; }
        public string Url { get; set; }
        public short HttpMethod { get; set; }
        public string Remark { get; set; }
        public short DelFalg { get; set; }
        public System.DateTime SubTime { get; set; }
        public bool IsMenu { get; set; }
        public virtual ICollection<UserInfo_DTO> UserInfos { get; set; }
        public virtual ICollection<Role_DTO> Roles { get; set; }
    }
}