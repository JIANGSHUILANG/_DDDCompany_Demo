using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApp.Models
{
    public class Person
    {
        [Required(ErrorMessage="必须填的")]
        public int ID { get; set; }
        [StringLength(20, ErrorMessage = "{0}在{2}位至{1}位之间", MinimumLength = 3)]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}