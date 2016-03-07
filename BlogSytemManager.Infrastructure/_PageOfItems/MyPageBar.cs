using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSytemManager.Infrastructure._PageOfItems
{
    public class MyPageBar
    {
        public static string ShowMyPageBar(int pageIndex, int pageCount)
        {
            if (pageCount == 1)
            {
                return string.Empty;
            }
            int start = pageIndex - 5;//计算起始位置，要求页面上有10个数字页码。
            if (start < 1)
            {
                start = 1;
            }
            int end = start + 9;
            if (end > pageCount)
            {
                end = pageCount;
                start = end - 9 > 1 ? end - 9 : 1;
            }
            StringBuilder sb = new StringBuilder();
            if (pageIndex > 1)
            {
                sb.Append("<li><a href='?pageIndex=1'>首页</a></li>");
            }
            for (int i = start; i <= end; i++)
            {
                if (i == pageIndex)
                {
                    sb.Append("<li class='am-active'><a href='#'>" + i + "</a></li>");
                }
                else
                {
                    sb.Append(string.Format("<li><a href='?pageIndex={0}'>{0}</a></li>", i));
                }
            }
            if (pageIndex < pageCount)
            {
                sb.Append(string.Format("<li><a href='?pageIndex={0}'>末页</a></li>", pageCount));
            }
            return sb.ToString();
        }
    }
}
