using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirst_03使用.Models
{
    public class UserInfo_DTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength(maximumLength: 10, ErrorMessage = "最大长度为：10")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(maximumLength: 10, ErrorMessage = "最大长度为：10")]
        public string UserPass { get; set; }
        public System.DateTime RegTime { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Role_DTO> Roles { get; set; }
        public virtual ICollection<ActionInfo_DTO> ActionInfos { get; set; }
    }
}