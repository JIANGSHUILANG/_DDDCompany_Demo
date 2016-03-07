using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcApp.Models.Extension
{
    /// <summary>
    /// MVC为Html对象建立一个扩展方法
    /// </summary>
    public static class MvcHtmlHelper
    {
        /// <summary>
        /// 对于，直接在页面上使用我们的方法，还是差了一步，那就是，要在web.config里把         MvcApp.Models.Extension_Methods   名称 空间加上，页面上才能访问的到：
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static MvcHtmlString Create_Text(this HtmlHelper html,string lable)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<input type='radio' value='1' name='sex' />男");
            sb.Append("<input type='radio' value='0' name='sex'  />女");
            return MvcHtmlString.Create(sb.ToString());
        }
    }
}
