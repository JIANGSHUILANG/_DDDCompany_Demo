using BlogSytemManager.AdmianWeb.Models;
using BlogSytemManager.AdmianWeb.Models._Manager;
using BlogSytemManager.DomainObject;
using BlogSytemManager.Infrastructure.Communication;
using BlogSytemManager.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BlogSytemManager.AdmianWeb.Controllers
{
    public class HomeController : BaseAdminController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonalSave(UserInfoObject Model)
        {
            MessageStaus message = default(MessageStaus);
            using (ServiceProxy<IUserInfoService> client = new ServiceProxy<IUserInfoService>())
            {
                if (Model == null)
                {
                    return HttpNotFound();
                }
                Session["MessageStaus"] = message = client.Channel.UpdateUserInfo(Model) ? MessageStaus.修改失败 : MessageStaus.修改成功;
            }
            return RedirectToAction("Index");
        }

        public bool UpLoadFile()
        {
            HttpPostedFileBase file = Request.Files["head_image"];
            var filename = file.FileName;
            return true;
        }
    }
}
