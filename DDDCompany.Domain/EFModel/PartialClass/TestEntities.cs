using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDCompany.Domain.EFModel
{
    [Export(typeof(DbContext))]
    public partial class TestEntities : DbContext
    {
    }
}
