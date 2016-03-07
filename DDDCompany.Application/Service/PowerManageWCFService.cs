using DDDCompany.Application.IService;
using DDDCompany.Domain.IRepositories;
using DDDCompany.Domain.IRepositories.Base;
using DDDCompany.DtoModel.Model;
using DDDCompany.Infrastructure.MEF;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace DDDCompany.Application.Service
{
    [Export(typeof(IPowerManageWCFService))]
    [ServiceClass]
    public class PowerManageWCFService : BaseService, IPowerManageWCFService
    {
     
        [Import]
        public IUserRepository userRepository { get; set; }

        [Import]
        public IDepartmentRepository departmentRepository { get; set; }

        [Import]
        public IMenuRepository menuRepository { get; set; }

        [Import]
        public IRoleRepository roleRepository { get; set; }






       public  List<DTO_User> Get__AllUser()
        {

            return base.GetDTOByLamda<DTO_User, DDDCompany.Domain.EFModel.User>(userRepository);
        }
    }
}
