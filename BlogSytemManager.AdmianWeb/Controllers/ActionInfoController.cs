﻿using System;
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
    public class ActionInfoController : BaseAdminController
    {
        #region CURD
        public ActionResult Index(int pageIndex = 1, int pageSize = 15)
        {
            if (Session["MessageStaus"] != null)
            {
                ViewBag.message = Session["MessageStaus"].ToString();
                Session.Remove("MessageStaus");
            }
            var temp = new ActionInfoObjectPageOfItems();
            using (ServiceProxy<IActionInfoService> client = new ServiceProxy<IActionInfoService>())
            {
                temp = client.Channel.GetActionInfopageOfitems(pageIndex, pageSize, new ActionInfoObjectPageOfItems());
                ViewBag.AllCount = temp.AllCount;
                ViewBag.pageIndex = pageIndex;
                ViewBag.pageCount = temp.TotalCount;
            }
            return View((List<ActionInfoObject>)temp.ActionInfoObjectLists);
        }

        public ActionResult Details(string id = null)
        {
            var temp = new ActionInfoObject();
            using (ServiceProxy<IActionInfoService> client = new ServiceProxy<IActionInfoService>())
            {
                temp = client.Channel.GetActionInfoById(Convert.ToInt32(id));
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

        public ActionResult Create(ActionInfoObject model)
        {
            if (ModelState.IsValid)
            {
                using (ServiceProxy<IActionInfoService> client = new ServiceProxy<IActionInfoService>())
                {
                    var temp = client.Channel.CreateActionInfo(model);
                }
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(string id = null)
        {

            var temp = new ActionInfoObject();
            using (ServiceProxy<IActionInfoService> client = new ServiceProxy<IActionInfoService>())
            {
                temp = client.Channel.GetActionInfoById(Convert.ToInt32(id));
                if (temp == null)
                {
                    return HttpNotFound();
                }
            }
            return View(temp);
        }

        [HttpPost]
        public ActionResult Edit(ActionInfoObject model)
        {
            MessageStaus message = default(MessageStaus);
            if (ModelState.IsValid)
            {
                using (ServiceProxy<IActionInfoService> client = new ServiceProxy<IActionInfoService>())
                {
                    if (model == null)
                    {
                        return HttpNotFound();
                    }
                    message = client.Channel.UpdateActionInfo(model) ? MessageStaus.修改失败 : MessageStaus.修改成功;
                }
            }
            Session["MessageStaus"] = message;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id = null)
        {
            MessageStaus message = default(MessageStaus);
            var temp = new ActionInfoObject();
            using (ServiceProxy<IActionInfoService> client = new ServiceProxy<IActionInfoService>())
            {
                temp = client.Channel.GetActionInfoById(Convert.ToInt32(id));
                if (temp == null)
                {
                    return HttpNotFound();
                }
                message = client.Channel.DeleteActionInfoById(Convert.ToInt32(id)) ? MessageStaus.操作失败 : MessageStaus.操作成功;
            }
            Session["MessageStaus"] = message;
            return RedirectToAction("Index");
        }

        public ActionResult Deletes(string[] ids)
        {
            MessageStaus message = default(MessageStaus);
            using (ServiceProxy<IActionInfoService> client = new ServiceProxy<IActionInfoService>())
            {
                if (ids == null)
                {
                    return HttpNotFound();
                }
                message = client.Channel.DeleteActionInfos(ids) ? MessageStaus.操作失败 : MessageStaus.操作成功;
            }
            Session["MessageStaus"] = message;
            return RedirectToAction("Index");
        }
        #endregion
    }
}