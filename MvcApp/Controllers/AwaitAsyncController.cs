using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class AwaitAsyncController : Controller
    {
        //
        // GET: /AwaitAsync/

        public async Task<ActionResult> Index()
        {

            var result = await Task.Factory.StartNew(() =>
            {
                return GetCnblogs("http://www.cnblogs.com/");
            });
            
            return Content(result.Result);
        }

        public async Task<string> GetCnblogs(string url)
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            var response = await client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return default(string);
            }
        }

    }
}
