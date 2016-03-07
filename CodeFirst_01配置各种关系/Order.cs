﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_01配置各种关系
{
    public class Order
    {
        public int ID { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual UserInfo UserInfo { get; set; }
        public Order()
        {
            this.Products = new List<Product>();
        }
    }
}
