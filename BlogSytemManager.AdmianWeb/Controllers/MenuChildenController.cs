using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogSytemManager.DomainObject;
using BlogSytemManager.Infrastructure.Communication;
using BlogSytemManager.IService;
using BlogSytemManager.AdmianWeb.Models;

namespace BlogSytemManager.AdmianWeb.Controllers
{
    public class MenuChildenController : BaseAdminController
    {
        #region CURD
        public ActionResult Index(int pageIndex = 1, int pageSize = 15)
        {
            if (Session["MessageStaus"] != null)
            {
                ViewBag.message = Session["MessageStaus"].ToString();
                Session.Remove("MessageStaus");
            }
            var temp = new MenuChildenObjectPageOfItems();
            using (ServiceProxy<IMenuChildenService> client = new ServiceProxy<IMenuChildenService>())
            {
                temp = client.Channel.GetMenuChildenpageOfitems(pageIndex, pageSize, new MenuChildenObjectPageOfItems());
                ViewBag.AllCount = temp.AllCount;
                ViewBag.pageIndex = pageIndex;
                ViewBag.pageCount = temp.TotalCount;
            }
            return View((List<MenuChildenObject>)temp.MenuChildenObjectLists);
        }

        public ActionResult Details(string id = null)
        {
            var temp = new MenuChildenObject();
            using (ServiceProxy<IMenuChildenService> client = new ServiceProxy<IMenuChildenService>())
            {
                temp = client.Channel.GetMenuChildenById(Convert.ToInt32(id));
                if (temp == null)
                {
                    return HttpNotFound();
                }
            }
            return View(temp);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(MenuChildenObject model)
        {
            if (ModelState.IsValid)
            {
                using (ServiceProxy<IMenuChildenService> client = new ServiceProxy<IMenuChildenService>())
                {
                    var temp = client.Channel.CreateMenuChilden(model);
                }
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(string id = null)
        {

            var temp = new MenuChildenObject();
            using (ServiceProxy<IMenuChildenService> client = new ServiceProxy<IMenuChildenService>())
            {
                temp = client.Channel.GetMenuChildenById(Convert.ToInt32(id));
                if (temp == null)
                {
                    return HttpNotFound();
                }
            }
            return View(temp);
        }

        [HttpPost]
        public ActionResult Edit(MenuChildenObject model)
        {
            MessageStaus message = default(MessageStaus);
            if (ModelState.IsValid)
            {
                using (ServiceProxy<IMenuChildenService> client = new ServiceProxy<IMenuChildenService>())
                {
                    if (model == null)
                    {
                        return HttpNotFound();
                    }
                    message = client.Channel.UpdateMenuChilden(model) ? MessageStaus.修改失败 : MessageStaus.修改成功;
                }
            }
            Session["MessageStaus"] = message;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id = null)
        {
            MessageStaus message = default(MessageStaus);
            var temp = new MenuChildenObject();
            using (ServiceProxy<IMenuChildenService> client = new ServiceProxy<IMenuChildenService>())
            {
                temp = client.Channel.GetMenuChildenById(Convert.ToInt32(id));
                if (temp == null)
                {
                    return HttpNotFound();
                }
                message = client.Channel.DeleteMenuChildenById(Convert.ToInt32(id)) ? MessageStaus.操作失败 : MessageStaus.操作成功;
            }
            Session["MessageStaus"] = message;
            return RedirectToAction("Index");
        }

        public ActionResult Deletes(string[] ids)
        {
            MessageStaus message = default(MessageStaus);
            using (ServiceProxy<IMenuChildenService> client = new ServiceProxy<IMenuChildenService>())
            {
                if (ids == null)
                {
                    return HttpNotFound();
                }
                message = client.Channel.DeleteMenuChildens(ids) ? MessageStaus.操作失败 : MessageStaus.操作成功;
            }
            Session["MessageStaus"] = message;
            return RedirectToAction("Index");
        }
        #endregion
    }
}
