using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst_03使用.Controllers
{
    public class BaseAdminController : Controller
    {
        //
        // GET: /Base/

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

    }
}
