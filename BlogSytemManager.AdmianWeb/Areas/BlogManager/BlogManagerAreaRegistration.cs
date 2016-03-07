using System.Web.Mvc;

namespace BlogSytemManager.AdmianWeb.Areas.BlogManager
{
    public class BlogManagerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "BlogManager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BlogManager_default",
                "BlogManager/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
