using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BolgSytemManager.Domain.Base;
using BolgSytemManager.Domain.IRepositories;
using BolgSytemManager.Domain.Model;
namespace BlogSytemManager.Repository.Repositories
{
    public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {
    }
}
