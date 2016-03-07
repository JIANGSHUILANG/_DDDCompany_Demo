using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirst_02权限管理;
using CodeFirst_03使用.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst_03使用.Controllers
{
	public class UserInfoController : BaseAdminController
	{

	 IUserInfoService UserInfoservice = new UserInfoService();
		
		 public ActionResult Index()
        {

            var temp = UserInfoservice.LoadEntities(c => true).ToList();
            return View(temp);
        }

        
        public ActionResult Details(string id = null)
        {
            var temp = UserInfoservice.LoadEntities(c => c.ID == Convert.ToInt32(id)).FirstOrDefault();
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

       
        public ActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserInfo model)
        {
            if (ModelState.IsValid)
            {
                UserInfoservice.AddEntity(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        
        public ActionResult Edit(string id = null)
        {
            var temp = UserInfoservice.LoadEntities(c => c.ID == Convert.ToInt32(id)).FirstOrDefault();
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserInfo model)
        {
            if (ModelState.IsValid)
            {
                UserInfoservice.UpdateEntity(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

     
        public ActionResult Delete(string id = null)
        {
            var temp = UserInfoservice.LoadEntities(c => c.ID == Convert.ToInt32(id)).FirstOrDefault();
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }
	}
}
