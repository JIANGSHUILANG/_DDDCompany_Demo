using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class CheckModelController : Controller
    {
        //MVC模型验证前段展示
        List<Person> per = new List<Person>()
        {
        new Person() { ID = 1, Name = "张三", Age = 18 },
        new Person() { ID = 2, Name = "李四", Age = 22 }
        };

        public ActionResult Index()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            
            return View(per[0]);
        }


        //使用MVC为Html对象建立一个扩展方法
        public ActionResult Use_MvcHtmlHelper()
        {

            //前台要引用 ：@using MvcApp.Models.Extension
            //C:\Users\LoserTwo\Desktop\领域驱动设计\_DDDCompany\MvcApp\Models\Extension\MvcHtmlHelper.cs
            return View();
        }

        public ActionResult PartailCheckModel(Person p)
        {
            var temp = per.Where(c => c.ID == p.ID).FirstOrDefault();
            return View(temp);
        }

    }



    /// <summary>
    /// MVC中对HtmlHelper扩展方法
    /// </summary>
    public static class MvcHtmlExtensions
    {
        /// <summary>
        /// 从ModelState中返回指定键对应的验证的错误消息
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static MvcHtmlString ValidationMessageTextFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {

            var fieldName = ExpressionHelper.GetExpressionText(expression);

            var modelState = htmlHelper.ViewData.ModelState;
            if (!modelState.Keys.Contains(fieldName))
                return null;
            if (modelState[fieldName].Errors.Count == 0)
                return null;
            IList<string> errList = new List<string>();
            modelState[fieldName].Errors.ToList().ForEach(i =>
            {
                errList.Add(i.ErrorMessage);
            });
            return MvcHtmlString.Create(string.Join(",", errList));

        }
    }
}
