using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_02权限管理
{
    public class BaseDTO{ }

    //public partial class UserInfo_DTO : BaseDTO
    //{
    //    public int ID { get; set; }
    //    public string UserName { get; set; }
    //    public string UserPass { get; set; }
    //    public System.DateTime RegTime { get; set; }
    //    public string Email { get; set; }
    //    public virtual ICollection<Role> Roles { get; set; }
    //    public virtual ICollection<ActionInfo> ActionInfos { get; set; }
    //}

    //public partial class Role_DTO : BaseDTO
    //{
    //    public int ID { get; set; }
    //    public string RoleName { get; set; }
    //    public short DelFlag { get; set; }
    //    public short RoleType { get; set; }
    //    public System.DateTime SubTime { get; set; }
    //    public string Remark { get; set; }
    //    public virtual ICollection<UserInfo> UserInfos { get; set; }
    //    public virtual ICollection<ActionInfo> ActionInfos { get; set; }

    //}

    //public partial class ActionInfo_DTO : BaseDTO
    //{
    //    public int ID { get; set; }
    //    public string ActionInfoName { get; set; }
    //    public string Url { get; set; }
    //    public short HttpMethod { get; set; }
    //    public string Remark { get; set; }
    //    public short DelFalg { get; set; }
    //    public System.DateTime SubTime { get; set; }
    //    public bool IsMenu { get; set; }
    //    public virtual ICollection<UserInfo> UserInfos { get; set; }
    //    public virtual ICollection<Role> Roles { get; set; }

    //}

    //public class Menu_DTO  : BaseDTO
    //{
    //    public int ID { get; set; }
    //    public string MenuName { get; set; }
    //    public short DelFlag { get; set; }
    //    public System.DateTime SubTime { get; set; }

    //    public virtual Role Role { get; set; }
    //}

    //public class ActionGroup_DTO  : BaseDTO
    //{
    //    public int ID { get; set; }
    //    public string GroupName { get; set; }
    //    public short GroupType { get; set; }
    //    public string DelFlag { get; set; }
    //    public int Sort { get; set; }

    //    public virtual ICollection<ActionInfo> ActionInfo { get; set; }
    //    public virtual ICollection<Role> Role { get; set; }
    //}

    //public class Setting_DTO  : BaseDTO
    //{

    //}
}
