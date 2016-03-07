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
    public class RoleController : BaseAdminController
    {
        #region CURD
        public ActionResult Index(int pageIndex = 1, int pageSize = 15)
        {
            if (Session["MessageStaus"] != null)
            {
                ViewBag.message = Session["MessageStaus"].ToString();
                Session.Remove("MessageStaus");
            }
            var temp = new RoleObjectPageOfItems();
            using (ServiceProxy<IRoleService> client = new ServiceProxy<IRoleService>())
            {
                temp = client.Channel.GetRolepageOfitems(pageIndex, pageSize, new RoleObjectPageOfItems());
                ViewBag.AllCount = temp.AllCount;
                ViewBag.pageIndex = pageIndex;
                ViewBag.pageCount = temp.TotalCount;
            }
            return View((List<RoleObject>)temp.RoleObjectLists);
        }

        public ActionResult Details(string id = null)
        {
            var temp = new RoleObject();
            using (ServiceProxy<IRoleService> client = new ServiceProxy<IRoleService>())
            {
                temp = client.Channel.GetRoleById(Convert.ToInt32(id));
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
        public ActionResult Create(RoleObject model)
        {
            if (ModelState.IsValid)
            {
                using (ServiceProxy<IRoleService> client = new ServiceProxy<IRoleService>())
                {
                    model.DelFlag = 1;
                    model.RoleType = 1;
                    model.SubTime = DateTime.Now;
                    var temp = client.Channel.CreateRole(model);
                }
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(string id = null)
        {

            var temp = new RoleObject();
            using (ServiceProxy<IRoleService> client = new ServiceProxy<IRoleService>())
            {
                temp = client.Channel.GetRoleById(Convert.ToInt32(id));
                if (temp == null)
                {
                    return HttpNotFound();
                }
            }
            return View(temp);
        }

        [HttpPost]
        public ActionResult Edit(RoleObject model)
        {
            MessageStaus message = default(MessageStaus);
            if (ModelState.IsValid)
            {
                using (ServiceProxy<IRoleService> client = new ServiceProxy<IRoleService>())
                {
                    if (model == null)
                    {
                        return HttpNotFound();
                    }
                    message = client.Channel.UpdateRole(model) ? MessageStaus.修改失败 : MessageStaus.修改成功;
                }
            }
            Session["MessageStaus"] = message;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id = null)
        {
            MessageStaus message = default(MessageStaus);
            var temp = new RoleObject();
            using (ServiceProxy<IRoleService> client = new ServiceProxy<IRoleService>())
            {
                temp = client.Channel.GetRoleById(Convert.ToInt32(id));
                if (temp == null)
                {
                    return HttpNotFound();
                }
                message = client.Channel.DeleteRoleById(Convert.ToInt32(id)) ? MessageStaus.操作失败 : MessageStaus.操作成功;
            }
            Session["MessageStaus"] = message;
            return RedirectToAction("Index");
        }

        public ActionResult Deletes(string[] ids)
        {
            MessageStaus message = default(MessageStaus);
            using (ServiceProxy<IRoleService> client = new ServiceProxy<IRoleService>())
            {
                if (ids == null)
                {
                    return HttpNotFound();
                }
                message = client.Channel.DeleteRoles(ids) ? MessageStaus.操作失败 : MessageStaus.操作成功;
            }
            Session["MessageStaus"] = message;
            return RedirectToAction("Index");
        }
        #endregion
    }
}
