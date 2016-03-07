using BlogSytemManager.DomainObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using BlogSytemManager.IService;
using BlogSytemManager.Infrastructure.Communication;
namespace BlogSytemManager.AdmianWeb.Models._Manager
{
    public class Manager
    {
        public static int UID
        {
            get
            {
                return GetUID();
            }
        }
        public static UserInfoObject User
        {
            get
            {
                return GetUsers();
            }
        }

        /// <summary>
        /// 从票据获得UID
        /// </summary>
        private static int GetUID()
        {
            try
            {
                return GetUsers().ID;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 从票据获得User
        /// </summary>
        private static UserInfoObject GetUsers()
        {
            try
            {
                var session = HttpContext.Current.Request.Cookies["SessionId"];
                var username = HttpContext.Current.Request.Cookies["UserInfoName"];
                var userpassword = HttpContext.Current.Request.Cookies["UserPassword"];

                if (session != null)
                {
                    using (ServiceProxy<IUserInfoService> client = new ServiceProxy<IUserInfoService>())
                    {
                        var userinfo = client.Channel.GetAllUserInfo().Where(c => (c.Email == session.Value || c.cell == session.Value)).FirstOrDefault();
                        return userinfo;
                    }
                }
                if (username != null && userpassword != null)
                {
                    using (ServiceProxy<IUserInfoService> client = new ServiceProxy<IUserInfoService>())
                    {
                        var userinfo = client.Channel.GetAllUserInfo().Where(c => (c.Email == username.Value || c.cell == username.Value) && c.UserPass == userpassword.Value).FirstOrDefault();
                        return userinfo;
                    }
                }
                return null;

            }
            catch
            {
                return null;
            }
        }


    }
}