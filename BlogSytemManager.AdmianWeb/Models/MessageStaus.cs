using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSytemManager.AdmianWeb.Models
{
    public class ErrorModel
    {
        public string Error { get; set; }
        public int Status { get; set; }
    }

    public enum MessageStaus
    {
        修改成功 = 1,
        修改失败 = 2,
        操作成功 = 3,
        操作失败 = 4,
        用户名或密码错误 = 5,
        您没有权限访问此页面 = 6,

    }
}