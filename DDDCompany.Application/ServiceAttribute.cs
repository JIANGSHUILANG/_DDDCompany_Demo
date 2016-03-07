using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDCompany.Application
{
    /// <summary>
    /// 表示WCF服务接口
    /// </summary>
    public class ServiceInterfaceAttribute : Attribute
    {

    }

    /// <summary>
    /// 表示WCF服务接口的实现类
    /// </summary>
    public class ServiceClassAttribute : Attribute
    {
    }
}
