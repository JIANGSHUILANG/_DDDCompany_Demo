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
    public class UserInfoController : BaseAdminController
    {
        #region CURD
        public ActionResult Index(int pageIndex = 1, int pageSize = 15)
        {
            if (Session["MessageStaus"] != null)
            {
                ViewBag.message = Session["MessageStaus"].ToString();
                Session.Remove("MessageStaus");
            }
            var temp = new UserInfoObjectPageOfItems();
            using (ServiceProxy<IUserInfoService> client = new ServiceProxy<IUserInfoService>())
            {
                temp = client.Channel.GetUserInfopageOfitems(pageIndex, pageSize, new UserInfoObjectPageOfItems());
                ViewBag.AllCount = temp.AllCount;
                ViewBag.pageIndex = pageIndex;
                ViewBag.pageCount = temp.TotalCount;
            }
            return View((List<UserInfoObject>)temp.UserInfoObjectLists);
        }




        public ActionResult Details(string id = null)
        {
            var temp = new UserInfoObject();
            using (ServiceProxy<IUserInfoService> client = new ServiceProxy<IUserInfoService>())
            {
                temp = client.Channel.GetUserInfoById(Convert.ToInt32(id));
                if (temp == null)
                {
                    return HttpNotFound();
                }
            }
            return View(temp);
        }

        public ActionResult Create()
        {
            if (Session["UserInfoID"] != null)
            {
                ViewBag.UserInfo_ID = Session["UserInfoID"];
                Session.Remove("UserInfoID");
            }

            if (Session["MessageStaus"] != null)
            {
                ViewBag.message = Session["MessageStaus"].ToString();
                Session.Remove("MessageStaus");
            }
            var temp = new RoleObject[] { };
            var permissiontemp = new PermissionObject[] { };
            using (ServiceProxy<IRoleService> client = new ServiceProxy<IRoleService>())
            {
                ViewData["Role"] = client.Channel.GetAllRole();

                ServiceProxy<IPermissionService> permission = new ServiceProxy<IPermissionService>();
                ViewData["Permission"] = permission.Channel.GetAllPermission();

                ServiceProxy<IMenuService> menu = new ServiceProxy<IMenuService>();
                ViewData["Menu"] = menu.Channel.GetAllMenu();

                ServiceProxy<IActionInfoService> actioninfo = new ServiceProxy<IActionInfoService>();
                ViewData["ActionInfo"] = actioninfo.Channel.GetAllActionInfo();


            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserInfoObject model)
        {
            var temp = new UserInfoObject();
            using (ServiceProxy<IUserInfoService> client = new ServiceProxy<IUserInfoService>())
            {
                temp = client.Channel.CreateUserInfo(model);
            }

            Session["UserInfoID"] = temp.ID;
            Session["MessageStaus"] = temp == null ? MessageStaus.操作失败 : MessageStaus.操作成功;
            return RedirectToAction("Create");
        }

        [HttpPost]
        public ActionResult Autor(int userinfo_ID, string ActionInfos, string Menu, string Permission, int role)
        {
            using (ServiceProxy<IUserInfoService> client = new ServiceProxy<IUserInfoService>())
            {
                bool flag = client.Channel.ForUserInfoAutor(Permission, Menu, ActionInfos, role, userinfo_ID);
            }
            return View();
        }

        public ActionResult Edit(string id = null)
        {

            var temp = new UserInfoObject();
            using (ServiceProxy<IUserInfoService> client = new ServiceProxy<IUserInfoService>())
            {
                temp = client.Channel.GetUserInfoById(Convert.ToInt32(id));
                if (temp == null)
                {
                    return HttpNotFound();
                }
            }
            return View(temp);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(UserInfoObject model)
        {
            MessageStaus message = default(MessageStaus);
            if (ModelState.IsValid)
            {
                using (ServiceProxy<IUserInfoService> client = new ServiceProxy<IUserInfoService>())
                {
                    if (model == null)
                    {
                        return HttpNotFound();
                    }
                    message = client.Channel.UpdateUserInfo(model) ? MessageStaus.操作失败 : MessageStaus.操作成功;
                }
            }
            Session["MessageStaus"] = message;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id = null)
        {
            MessageStaus message = default(MessageStaus);
            var temp = new UserInfoObject();
            using (ServiceProxy<IUserInfoService> client = new ServiceProxy<IUserInfoService>())
            {
                temp = client.Channel.GetUserInfoById(Convert.ToInt32(id));
                if (temp == null)
                {
                    return HttpNotFound();
                }
                message = client.Channel.DeleteUserInfoById(Convert.ToInt32(id)) ? MessageStaus.操作失败 : MessageStaus.操作成功;
            }
            Session["MessageStaus"] = message;
            return RedirectToAction("Index");
        }

        public ActionResult Deletes(string[] ids)
        {
            MessageStaus message = default(MessageStaus);
            using (ServiceProxy<IUserInfoService> client = new ServiceProxy<IUserInfoService>())
            {
                if (ids == null)
                {
                    return HttpNotFound();
                }
                message = client.Channel.DeleteUserInfos(ids) ? MessageStaus.操作失败 : MessageStaus.操作成功;
            }
            Session["MessageStaus"] = message;
            return RedirectToAction("Index");
        }
        #endregion

        #region Public Function

        protected int[] Splitstrs(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return new int[0];
            }
            var strs = str.Split('|');
            int[] temp = new int[strs.Length];
            for (int i = 0; i < strs.Length; i++)
            {
                temp[i] = Convert.ToInt32(strs[i]);
            }
            return temp;
        }

        #endregion
    }
}


