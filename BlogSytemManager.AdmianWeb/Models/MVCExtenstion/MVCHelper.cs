using BlogSytemManager.AdmianWeb.Models._Manager;
using BlogSytemManager.DomainObject;
using BlogSytemManager.Infrastructure.Communication;
using BlogSytemManager.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BlogSytemManager.AdmianWeb.Models.MVCExtenstion
{
    public static class MVCHelper
    {
        public static MvcHtmlString Insert_Del_Edit_Audit(this HtmlHelper html, Dictionary<EnumInsert_Del_Edit_Audit, string> DIC)
        {

            StringBuilder SB = new StringBuilder();
            if (DIC.Count == 0) return null;


            if (Manager.User.UserName == "浪哥") { }


            SB.Append("<div class='am-btn-toolbar'>");
            SB.Append("<div class='am-btn-group am-btn-group-xs'>");
            var routes = HttpContext.Current.Request.RequestContext.RouteData.Values;
            if (routes.Count > 0)
            {
                var route = routes.FirstOrDefault().Value;
                var userinfo = _Manager.Manager.User;
                foreach (KeyValuePair<EnumInsert_Del_Edit_Audit, string> item in DIC)
                {
                    var strurl = string.Format("/{0}/{1}", route, item.Key.ToString());
                    var userinfoaction = userinfo.ActionInfos.Where(c => c.Url.Contains(strurl)).FirstOrDefault();
                    var userinforole = userinfo.Roles;
                    var userinforoleaction = new ActionInfoObject();
                    foreach (var role in userinforole)
                    {
                        userinforoleaction = role.ActionInfos.Where(c => c.Url.Contains(strurl)).FirstOrDefault();
                    }

                    if (userinfoaction != null || userinforoleaction != null)
                    {
                        if (item.Key == EnumInsert_Del_Edit_Audit.Create)
                        {
                            SB.AppendFormat("<a class='am-btn am-btn-default' href='{0}'><span class='am-icon-plus'></span>新增</a>", strurl);
                        }
                        if (item.Key == EnumInsert_Del_Edit_Audit.Edit)
                        {
                            SB.AppendFormat("<a class='am-btn am-btn-default am-btn-xs am-text-secondary' href='{0}?{1}'><span class='am-icon-pencil-square-o'></span>编辑</a>", strurl, item.Value);
                        }
                        if (item.Key == EnumInsert_Del_Edit_Audit.Delete)
                        {
                            SB.AppendFormat("<a class='am-btn am-btn-default am-btn-xs am-text-danger am-hide-sm-only' href='{0}?{1}'><span class='am-icon-trash-o'></span>删除</a>", strurl, item.Value);
                        }
                        if (item.Key == EnumInsert_Del_Edit_Audit.Audit)
                        {
                            SB.AppendFormat("<a  class='am-btn am-btn-default' href='/UserInfo/Audit' ><span class='am-icon-archive'></span>审核</a>", strurl);
                        }
                    }
                }
            }
            SB.Append("</div>");
            SB.Append("</div>");
            return MvcHtmlString.Create(SB.ToString());
        }
    }

    public enum EnumInsert_Del_Edit_Audit
    {
        Create,
        Delete,
        Edit,
        Audit
    }
}