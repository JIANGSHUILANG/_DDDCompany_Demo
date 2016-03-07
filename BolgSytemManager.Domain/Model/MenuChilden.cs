using BolgSytemManager.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolgSytemManager.Domain.Model
{
    public class MenuChilden : AggregateRoot
    {
       //public int ID { get; set; }
       //此菜单的上一级ID
       public int Parent_ID { get; set; }
       public string MenuChildenName { get; set; }
       public string Url { get; set; }
       public Nullable<DateTime> CreateTime { get; set; }
       public Nullable<DateTime> UpdateTime { get; set; }
       public int shot { get; set; }
       public string content { get; set; }
       public short DelFlag { get; set; }
       public string Remark { get; set; }
       public virtual Menu Menu{ get; set; }
    }
}
