using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeiXin.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //只用require.js  引入 main.js  实现跳转
            return View();
        }

        public ActionResult Show()
        {
            return View();
        }
    }
}
