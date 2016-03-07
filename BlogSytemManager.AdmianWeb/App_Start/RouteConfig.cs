using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlogSytemManager.AdmianWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //这句意思是忽略对扩展名为.axd文件的请求
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AdminLogin", action = "Index", id = UrlParameter.Optional }
            );


            routes.MapRoute(
              name: "Test",
              url: "{controller}/{action}/{id}.html",
              defaults: new { controller = "AdminLogin", action = "Index", id = UrlParameter.Optional }
          );
        }
    }
}