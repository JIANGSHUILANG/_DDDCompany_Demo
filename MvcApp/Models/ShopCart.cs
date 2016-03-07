using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Models
{
    public class ShopCart
    {

        public int ID { get; set; }
        [Required(ErrorMessage = "Must")]
        [StringLength(10, MinimumLength = 5)]
        public string CartName { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public DateTime BuyTime { get; set; }
    }
}