using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CodeFirst_03使用.Models
{
    public class PageOfItems<T> : List<T>, IPageOfItems<T>
    {

        public PageOfItems()
        {
        }

        public PageOfItems(IEnumerable<T> items)
        {
            AddRange(items);
        }
        #region IPageOfItems<T> Members

        public int PageNumber
        {
            get;
            set;
        }

        public int PageSize
        {
            get;
            set;
        }

        public int TotalItemCount
        {
            get;
            set;
        }

        public int TotalPageCount
        {
            get { return (int)Math.Ceiling((double)TotalItemCount / PageSize); }
        }

        public int StartPosition
        {
            get { throw new NotImplementedException(); }
        }

        public int EndPosition
        {
            get { throw new NotImplementedException(); }
        }

        public string PageNumberKey
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string UrlMeta
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        public  string ShowMyPageBar
        {
            get
            {
                if (TotalPageCount == 1)
                {
                    return string.Empty;
                }
                int start = PageNumber - 5;//计算起始位置，要求页面上有10个数字页码。
                if (start < 1)
                {
                    start = 1;
                }
                int end = start + 9;
                if (end > TotalPageCount)
                {
                    end = TotalPageCount;
                    start = end - 9 > 1 ? end - 9 : 1;
                }
                StringBuilder sb = new StringBuilder();
                if (PageNumber > 1)
                {
                    sb.Append("<li><a href='?pageIndex=1'>首页</a></li>");
                }
                for (int i = start; i <= end; i++)
                {
                    if (i == PageNumber)
                    {
                        sb.Append("<li class='am-active'><a href='#'>" + i + "</a></li>");
                    }
                    else
                    {
                        sb.Append(string.Format("<li><a href='?pageIndex={0}'>{0}</a></li>", i));
                    }
                }
                if (PageNumber < TotalPageCount)
                {
                    sb.Append(string.Format("<li><a href='?pageIndex={0}'>末页</a></li>", TotalPageCount));
                }
                return sb.ToString();
            }
           
          
     
        }
    }


    public interface IPageOfItems<out T> : IEnumerable<T>
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        int PageNumber { get; set; }

        /// <summary>
        /// 页大小
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// 所有项的总量
        /// </summary>
        int TotalItemCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        int TotalPageCount { get; }

        /// <summary>
        /// 其实位置
        /// </summary>
        int StartPosition { get; }

        /// <summary>
        /// 结束位置
        /// </summary>
        int EndPosition { get; }

        /// <summary>
        /// 应该为非空
        /// </summary>
        string PageNumberKey { get; set; }

        string UrlMeta { get; set; }
    }
}