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
    public class MenuController : BaseAdminController
    {
        #region CURD

        public ActionResult Index(int pageIndex = 1, int pageSize = 15)
        {
            if (Session["MessageStaus"] != null)
            {
                ViewBag.message = Session["MessageStaus"].ToString();
                Session.Remove("MessageStaus");
            }
            var temp = new MenuObjectPageOfItems();
            using (ServiceProxy<IMenuService> client = new ServiceProxy<IMenuService>())
            {
                temp = client.Channel.GetMenupageOfitems(pageIndex, pageSize, new MenuObjectPageOfItems());
                ViewBag.AllCount = temp.AllCount;
                ViewBag.pageIndex = pageIndex;
                ViewBag.pageCount = temp.TotalCount;
            }
            return View((List<MenuObject>)temp.MenuObjectLists);
        }

        public ActionResult Details(string id = null)
        {
            var temp = new MenuObject();
            using (ServiceProxy<IMenuService> client = new ServiceProxy<IMenuService>())
            {
                temp = client.Channel.GetMenuById(Convert.ToInt32(id));
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

        public ActionResult Create(MenuObject model)
        {
            if (ModelState.IsValid)
            {
                using (ServiceProxy<IMenuService> client = new ServiceProxy<IMenuService>())
                {
                    var temp = client.Channel.CreateMenu(model);
                }
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(string id = null)
        {

            var temp = new MenuObject();
            using (ServiceProxy<IMenuService> client = new ServiceProxy<IMenuService>())
            {
                temp = client.Channel.GetMenuById(Convert.ToInt32(id));
                if (temp == null)
                {
                    return HttpNotFound();
                }
            }
            return View(temp);
        }

        [HttpPost]
        public ActionResult Edit(MenuObject model)
        {
            MessageStaus message = default(MessageStaus);
            if (ModelState.IsValid)
            {
                using (ServiceProxy<IMenuService> client = new ServiceProxy<IMenuService>())
                {
                    if (model == null)
                    {
                        return HttpNotFound();
                    }
                    message = client.Channel.UpdateMenu(model) ? MessageStaus.修改失败 : MessageStaus.修改成功;
                }
            }
            Session["MessageStaus"] = message;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id = null)
        {
            MessageStaus message = default(MessageStaus);
            var temp = new MenuObject();
            using (ServiceProxy<IMenuService> client = new ServiceProxy<IMenuService>())
            {
                temp = client.Channel.GetMenuById(Convert.ToInt32(id));
                if (temp == null)
                {
                    return HttpNotFound();
                }
                message = client.Channel.DeleteMenuById(Convert.ToInt32(id)) ? MessageStaus.操作失败 : MessageStaus.操作成功;
            }
            Session["MessageStaus"] = message;
            return RedirectToAction("Index");
        }

        public ActionResult Deletes(string[] ids)
        {
            MessageStaus message = default(MessageStaus);
            using (ServiceProxy<IMenuService> client = new ServiceProxy<IMenuService>())
            {
                if (ids == null)
                {
                    return HttpNotFound();
                }
                message = client.Channel.DeleteMenus(ids) ? MessageStaus.操作失败 : MessageStaus.操作成功;
            }
            Session["MessageStaus"] = message;
            return RedirectToAction("Index");
        }
        #endregion

    }
}
