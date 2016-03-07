using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using MvcApp.Models;
namespace MvcApp.Controllers
{
    public class ShopCartDemoController : Controller
    {
        //
        // GET: /ShopCartDemo/
        //微软提供的需要下载： Microsoft ASP.NET Identity EntityFramework.dll

        //实现伪静态的.dll  aspnet_isapi.dll
        public ActionResult Index()
        {
            return View();
        }
        
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public string CreateShopCart(ShopCart Model)
        {

            var msg = "";
            if (!ModelState.IsValid)
            {
                msg = "ISOK";
                return "";
            }
            else
            {
                ModelState.AddModelError("CartName", "购物车名不能为空");
            }
            return "";
        }

    }
}
