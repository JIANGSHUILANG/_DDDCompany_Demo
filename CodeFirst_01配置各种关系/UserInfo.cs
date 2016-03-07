using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_01配置各种关系
{
    public class UserInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Nullable<DateTime> CreateTime { get; set; }
        public Nullable<DateTime> LoginTime { get; set; }
        //如果我们要到一对主从表增加级联操作，则要在主表中的引用属性上增加Required关键字
        public Nullable<int> OtherInfo_Id { get; set; }
        public Nullable<int> Address_Id { get; set; }
        public virtual OtherInfo OtherInfo { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public UserInfo()
        {
            this.Orders = new List<Order>();
        }
    }
}
