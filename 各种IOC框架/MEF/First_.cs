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
    //MEF的使用步骤主要分三步：宿主MEF并组合部件、标记对象的导出、对象的导入使用。
    //引用 System.ComponentModel.Composition.dll组件
    class First_
    {
        //导入对象使用
        [Import("Chinese_hello")] //拿到Export("Chinese_hello")的类
        public IPerson Iperson { get; set; }

        [ImportMany] //拿到所有实现Isay接口的类
        public IEnumerable<ISay> Isay { get; set; }

        //static void Main(string[] args)
        //{
        //    //First first = new First();
        //    //first.ComponentPart();
        //    //var read = first.Iperson.SayHello("李磊");
        //    //Console.WriteLine(read);
        //    //Console.Read();


        //    First first = new First();
        //    first.ComponentPart();
        //    IEnumerable<ISay> isays = first.Isay;
        //    Console.WriteLine(isays.Count());
        //    foreach (var item in isays)
        //    {
        //        var read = item.SayHello("李磊");
        //        Console.WriteLine(read);
        //    }
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
    #region IPerson

    public interface IPerson
    {
        string SayHello(string name);
    }

    //申明对象可导出
    [Export("Chinese_hello", typeof(IPerson))]
    public class Chinese : IPerson
    {
        public string SayHello(string name)
        {
            return "你好：" + name;
        }
    }
    //申明对象可导出
    [Export("America_hello", typeof(IPerson))]
    public class America : IPerson
    {
        public string SayHello(string name)
        {
            return "Hello:" + name;
        }
    }
    #endregion

    #region ISay

    //使用ImportMany的时候对应的Export不能有chinese_hello这类string参数
    public interface ISay
    {
        string SayHello(string name);
    }

    //申明对象可导出
    [Export(typeof(ISay))]
    public class Father : ISay
    {
        public string SayHello(string name)
        {
            return "你好：" + name;
        }
    }
    //申明对象可导出
    [Export(typeof(ISay))]
    public class Mather : ISay
    {
        public string SayHello(string name)
        {
            return "Hello:" + name;
        }
    }
    #endregion
}
