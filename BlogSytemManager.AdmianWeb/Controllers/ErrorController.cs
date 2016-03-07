using System.Web;
using System.Web.Mvc;
using BlogSytemManager.DomainObject;
using BlogSytemManager.Infrastructure.Communication;
using BlogSytemManager.IService;
using BlogSytemManager.AdmianWeb.Models;
using Newtonsoft.Json;
using System;
namespace BlogSytemManager.AdmianWeb.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            var temp = new ErrorModel();
            var error = Request.QueryString["error"];
            if (!string.IsNullOrWhiteSpace(error))
            {
                try
                {
                    temp = JsonConvert.DeserializeObject<ErrorModel>(error);
                    temp.Error = Server.UrlDecode(temp.Error);
                }
                catch (Exception ex)
                {
                    temp.Status = 0;
                    temp.Error = ex.StackTrace;
                }
            }
            return View(temp);
        }
    }
}