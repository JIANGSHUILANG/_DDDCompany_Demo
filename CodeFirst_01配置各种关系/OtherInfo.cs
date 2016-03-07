using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_01配置各种关系
{
   public class OtherInfo
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Cell { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
