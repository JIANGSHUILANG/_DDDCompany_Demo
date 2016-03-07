using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
namespace MvcApplication1.Controllers
{
    public class TestController : ApiController
    {
        //
        // GET: /Test/
        [HttpPost]
        public object Index(string base64str, int photo_type)
        {
            int i = 1 + 2;
            return i;
        }

    }
}
