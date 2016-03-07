using DDDCompany.Domain.EFModel;
using DDDCompany.DtoModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DDDCompany.Application.IService
{
    /// <summary>
    /// 权限管理模块接口契约
    /// </summary>
    [ServiceInterface]
    [ServiceContract]
    public interface IPowerManageWCFService
    {
        [OperationContract]
        List<DTO_User> Get__AllUser();
    }
}
