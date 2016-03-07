using BlogSytemManager.DomainObject;
using BlogSytemManager.Infrastructure.Communication;
using BlogSytemManager.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using BlogSytemManager.AdmianWeb.Models;
using BlogSytemManager.AdmianWeb.Models._Manager;

namespace BlogSytemManager.AdmianWeb.Controllers
{
    public class AdminLoginController : Controller
    {
        public AdminLoginController()
        {

        }
        public ActionResult Index()
        {
            
            if (Manager.User != null)
            {
                return RedirectToAction("Index","Home");
            }
            if (Session["MessageStaus"] != null)
            {
                ViewBag.message = Session["MessageStaus"].ToString();
                Session.Remove("MessageStaus");
            }
            return View();
        }

        public ActionResult Login(string email, string password, int remberme = 0)
        {
            using (ServiceProxy<IUserInfoService> client = new ServiceProxy<IUserInfoService>())
            {
                var temp = client.Channel.GetAllUserInfo().Where(c => (c.Email == email || c.cell == email) && c.UserPass == password).FirstOrDefault();
                if (temp != null)
                {
                    if (remberme > 0)
                        WriteCookie(temp, 7);
                    else
                        WriteCookie(temp, 1);
                }
                else
                {
                    Session["MessageStaus"] = MessageStaus.用户名或密码错误;
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index", "Home");
        }
        public ActionResult LoginOut()
        {
            RemoveCookie("SessionId");
            return RedirectToAction("Index");
        }

        public ActionResult FindPassWord()
        {
            return View();
        }

        public void WriteCookie(UserInfoObject userinfo, int days)
        {
            if (days == 7)
            {
                HttpCookie cookie1 = new HttpCookie("UserInfoName", string.IsNullOrWhiteSpace(userinfo.Email) ? userinfo.cell : userinfo.Email);
                HttpCookie cookie2 = new HttpCookie("UserPassword", userinfo.UserPass);
                cookie1.Expires = DateTime.Now.AddDays(7);
                cookie2.Expires = DateTime.Now.AddDays(7);
                HttpContext.Response.Cookies.Add(cookie1);
                HttpContext.Response.Cookies.Add(cookie2);
            }
            if (days == 1)
            {

                Response.Cookies["SessionId"].Value = string.IsNullOrWhiteSpace(userinfo.Email) ? userinfo.cell : userinfo.Email;
            }
        }

        public void RemoveCookie(string CookieName)
        {
            HttpContext.Response.Cookies[CookieName].Expires = DateTime.Now.AddDays(-1);
        }
    }
}
