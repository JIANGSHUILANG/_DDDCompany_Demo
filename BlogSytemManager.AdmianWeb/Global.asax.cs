using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BlogSytemManager.AdmianWeb
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801



    public class MvcApplication : System.Web.HttpApplication
    {
        // 移除WebForm视图引擎
        public void RemoveEnite()
        {
            var viewenite = ViewEngines.Engines;
            var webformengines = viewenite.OfType<WebFormViewEngine>().FirstOrDefault();
            if (webformengines != null)
            {
                viewenite.Remove(webformengines);
            }
        }

        //Route路由问题

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RemoveEnite(); // 移除WebForm视图引擎
            MvcHandler.DisableMvcResponseHeader = false;//隐藏服务器给浏览器展示MVC的版本号
          
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            #region HttpAppliation 的19个管道事件

            AcquireRequestState += MvcApplication_AcquireRequestState;

            EndRequest+=MvcApplication_EndRequest;


            //AuthenticateRequest += MvcApplication_AuthenticateRequest;
            //AuthorizeRequest += MvcApplication_AuthorizeRequest;
            //BeginRequest += MvcApplication_BeginRequest;
            //Disposed += MvcApplication_Disposed;
            //EndRequest += MvcApplication_EndRequest;
            //Error += MvcApplication_Error;
            //LogRequest += MvcApplication_LogRequest;
            
            //MapRequestHandler;
            //PostAcquireRequestState;
            //PostAuthenticateRequest;
            //PostAuthorizeRequest;
            //PostLogRequest;
            //PostMapRequestHandler;
            //PostReleaseRequestState;
            //PostRequestHandlerExecute;
            //PostResolveRequestCache;
            //PostUpdateRequestCache;
            //PreRequestHandlerExecute;
            //PreSendRequestContent;
            //PreSendRequestHeaders;
            //ReleaseRequestState;
            //RequestCompleted;
            //ResolveRequestCache;
            //UpdateRequestCache;
            #endregion
        }

       

        void MvcApplication_LogRequest(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void MvcApplication_Error(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void MvcApplication_EndRequest(object sender, EventArgs e)
        {
           
        }

        void MvcApplication_Disposed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void MvcApplication_AuthorizeRequest(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void MvcApplication_AuthenticateRequest(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void MvcApplication_AcquireRequestState(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

   
    }
}