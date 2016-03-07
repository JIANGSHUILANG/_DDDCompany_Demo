using System.Web;
using System.Web.Mvc;
using BlogSytemManager.DomainObject;
using BlogSytemManager.Infrastructure.Communication;
using BlogSytemManager.IService;
using BlogSytemManager.AdmianWeb.Models;
using Newtonsoft.Json;
using System;
using BlogSytemManager.AdmianWeb.Areas.BlogManager.Models;
using System.Web.Security;
namespace BlogSytemManager.AdmianWeb.Areas.BlogManager.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Index()
        {
            V_Blog blog = new V_Blog();
            ViewBag.SelectList = blog.TypeList; //下来菜单
            //ViewData["SelectList"] = blog.TypeList;
            return View();
        }


        [ValidateAntiForgeryToken()]
        public ActionResult Save(V_Blog blog)
        {
            var selectvalue = Request.Form["SelectList"]; //后台获取DrowList的值
            //
            if (!ModelState.IsValid)
            {
                //return red
                //Membership.ValidateUser;
            }
            return View();
        }

    }
}