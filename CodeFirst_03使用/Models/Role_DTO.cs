using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirst_03使用.Models
{
    public class Role_DTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "角色名不能为空")]
        [StringLength(maximumLength: 10, ErrorMessage = "最大长度为：10")]
        public string RoleName { get; set; }
        public short DelFlag { get; set; }
        public short RoleType { get; set; }
        public System.DateTime SubTime { get; set; }
        public string Remark { get; set; }
        public virtual ICollection<UserInfo_DTO> UserInfos { get; set; }
        public virtual ICollection<ActionInfo_DTO> ActionInfos { get; set; }
    }
}