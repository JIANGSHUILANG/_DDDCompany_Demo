using System.Web;
using System.Web.Mvc;

namespace CodeFirst_03使用
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}