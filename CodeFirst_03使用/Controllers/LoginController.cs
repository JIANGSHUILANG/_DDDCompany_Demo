using CodeFirst_02权限管理;
using CodeFirst_03使用.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst_03使用.Controllers
{
    public class LoginController : Controller
    {

        // 引用 CodeFirst_02权限管理.dll
        // GET: /Login/
        IUserInfoService userinfoservice = new UserInfoService();

        //LoginController()
        //{
        //    AutoMapper.Mapper.CreateMap<UserInfo_DTO, UserInfo>();
        //    AutoMapper.Mapper.CreateMap<UserInfo, UserInfo_DTO>();
        //}

        public ActionResult Index()
        {

            var temp = userinfoservice.LoadEntities(c => true).ToList();
            return View(temp);
        }

        //
        // GET: /Temo/Details/5

        public ActionResult Details(string id = null)
        {
            var temp = userinfoservice.LoadEntities(c => c.ID == Convert.ToInt32(id)).FirstOrDefault();
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        //
        // GET: /Temo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Temo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserInfo userinfo)
        {
            if (ModelState.IsValid)
            {
                userinfoservice.AddEntity(userinfo);
                return RedirectToAction("Index");
            }

            return View(userinfo);
        }

        //
        // GET: /Temo/Edit/5

        public ActionResult Edit(string id = null)
        {
            var temp = userinfoservice.LoadEntities(c => c.ID == Convert.ToInt32(id)).FirstOrDefault();
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        //
        // POST: /Temo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserInfo userinfo)
        {
            if (ModelState.IsValid)
            {
                userinfoservice.UpdateEntity(userinfo);
                return RedirectToAction("Index");
            }
            return View(userinfo);
        }

        //
        // GET: /Temo/Delete/5

        public ActionResult Delete(string id = null)
        {
            var temp = userinfoservice.LoadEntities(c => c.ID == Convert.ToInt32(id)).FirstOrDefault();
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        //
        // POST: /Temo/Delete/5


        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            //base.Dispose(disposing);
        }
    }
}
