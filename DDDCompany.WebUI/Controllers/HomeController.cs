using DDDCompany.Application.IService;
using DDDCompany.Infrastructure.MEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.Composition;
using DDDCompany.Application.Service;
namespace DDDCompany.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        //[Import]
        //IPowerManageWCFService powerManageservice { get; set; }
    
        public ActionResult Index()
        {
            IPowerManageWCFService powerManageservice = new PowerManageWCFService();
            var users = powerManageservice.Get__AllUser();
            return View();

        }

    }
}
