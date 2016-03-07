using BlogSytemManager.DomainObject;
using BlogSytemManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BlogSytemManager.IService
{
    [ServiceContract(Namespace = "http://www.CC.com")]
    public partial interface IBlogService : IApplicationServiceContract
    {
       
    }
}
