using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_01配置各种关系
{
    public class Product
    {
        public int ID { get; set; }
        public string Product_Name { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public Product()
        { 
         //一个商品对应多个
           this.Orders = new List<Order>();
        }
    }
}
