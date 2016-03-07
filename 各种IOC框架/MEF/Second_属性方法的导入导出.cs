using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 各种IOC框架.MEF
{
    class Second_属性方法的导入导出
    {
        [Import("TestProperty")]
        public string ConsloeTest { get; set; }

        [Import("HelloName")]
        public Action<string> TestGetHelloName { get; set; }

        //static void Main(string[] args)
        //{
        //    Second_属性方法的导入导出 second = new Second_属性方法的导入导出();
        //    second.ComponentPart();//调用宿主组合容器
        //    Console.WriteLine(second.ConsloeTest);
        //    second.TestGetHelloName("小明");
        //    Console.Read();
        //}

        //宿主MEF组合部件
        void ComponentPart()
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);
            //将部件（part） 和宿主程序添加到组合容器 !!
            container.ComposeParts(this);
        }
    }

    public class TestPropertyImport
    {
        //属性的导入
        [Export("TestProperty")]
        public string TestMPort { get { return "测试使用"; } }

        //方法的导入和导出是通过匿名委托的方式实现的
        [Export("HelloName", typeof(Action<string>))]
        public void GetHelloName(string name)
        {
            Console.WriteLine("Hello：" + name);
        }
    }
}
