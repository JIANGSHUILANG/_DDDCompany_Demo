using BlogSytemManager.AdmianWeb.Models._Manager;
using BlogSytemManager.DomainObject;
using BlogSytemManager.Infrastructure.Communication;
using BlogSytemManager.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using BlogSytemManager.AdmianWeb.Models;
using System.Linq.Expressions;
using System.Reflection;
namespace BlogSytemManager.AdmianWeb.Controllers
{
    public class BaseAdminController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var ctx = filterContext.HttpContext;
            bool newsession = ctx.Session.IsNewSession; 
            //True:说明是新的Session第一次登陆,False:旧的Session


            //判断cookie
            var userinfo = Manager.User;

            if (userinfo != null)
            {
                if (userinfo.UserName == "浪哥")
                    return;

                var routes = ControllerContext.RequestContext.RouteData.Values;  //routevalues[0]是：Home   routevalues[1]是：Index
                string url = string.Empty;
                foreach (var item in routes)
                {
                    //当前请求地址
                    url += "/" + routes[item.Key];
                    if (url == "/Home/Index")
                        return;
                }

                var action_intercept = string.Empty;
                var roleaction_intercept = string.Empty;
                #region 用户权限

                action_intercept = (from c in userinfo.ActionInfos
                                    where c.Url == url
                                    select c.Url).FirstOrDefault();

                #endregion

                #region 角色权限

                foreach (var item in userinfo.Roles)
                {
                    roleaction_intercept = (from c in item.ActionInfos
                                            where c.Url == url
                                            select c.Url).FirstOrDefault();
                    break;
                }

                #endregion
                if (string.IsNullOrWhiteSpace(action_intercept) && string.IsNullOrWhiteSpace(roleaction_intercept))
                {
                    //  filterContext.Result  跳转一定要用：filterContext.Result= Redirect("......")
                    filterContext.Result = Redirect(string.Format("/Error/Index?error={0}", JsonConvert.SerializeObject(new ErrorModel()
                        {
                            Status = (int)MessageStaus.您没有权限访问此页面,
                            Error = Server.UrlEncode(MessageStaus.您没有权限访问此页面.ToString())
                        })));
                    return;
                }
            }
            else //Cookie中没有用户信息
            {
                //  filterContext.Result  跳转一定要用：filterContext.Result= Redirect("......")
                filterContext.Result = Redirect("/AdminLogin/Index");
            }

        }

        public ActionResult PublicSearch(string controllname, string wherename, string wherevalue)
        {
            return null;
            
            
        }
    }
}
