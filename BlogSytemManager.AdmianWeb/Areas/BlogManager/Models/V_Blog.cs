using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSytemManager.AdmianWeb.Areas.BlogManager.Models
{
    public class V_Blog
    {
        public V_Blog()
        {
            var list = new List<SelectListItem>()
            {
                new SelectListItem(){Text="C#",Value="1"},
                new SelectListItem(){Text="Java",Value="2"},
                new SelectListItem(){Text="Html5",Value="3"},
                new SelectListItem(){Text="Unity3D",Value="4"},
                new SelectListItem(){Text="Python",Value="5"},
                new SelectListItem(){Text="C++",Value="6"}
            };
            this.TypeList = list;
        }

        [DisplayName("分类")]
        public IEnumerable<SelectListItem> TypeList { get; set; }

        [DisplayName("标示ID")]
        public int ID { get; set; }

        [DisplayName("标题")]
        //[Range(1, int.MaxValue, ErrorMessage = "输入大于等于1的数字")]
        [StringLength(15)]
        [Required(ErrorMessage = "标题不能为空")]
        public string Title { get; set; }

        [DisplayName("邮箱")]
        [RegularExpression(@"^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$",
 ErrorMessage = "请输入正确的Email格式\n示例：abc@123.com")]
        public string Email { get; set; }
    }

    public class AyscBlogContent
    {

        //Remote异步请求验证，在[HttpGet]时获取指定Controller里面的指定方法验证，此方法必须是[HttpGet]标记的，返回类型为Json类型的JavaScript对象
        [Remote("Info", "Blog", ErrorMessage = "已存在改详情")]
        public string Content { get; set; }
    }

    public class CompareValuesAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }
    }
}