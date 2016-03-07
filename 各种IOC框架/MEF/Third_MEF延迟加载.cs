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
    //当装配一个组件的时候，当前组件里面的所有的Import的变量都自动去找到对应的Export而执行了实例化，有些时候，出于程序效率的考虑，不需要立即实例化对象，而是在使用的时候才对它进行实例化。MEF里面也有这种延迟加载的机制
    class Third_MEF延迟加载
    {
        [Import("Chinese_hello")]
        public IPersons Iperson { get; set; }

         [Import("America_hello")]
        public Lazy<IPersons> LazyIperson { get; set; }

        //static void Main(string[] args)
        //{
        //    var Third_MEF延迟加载 = new Third_MEF延迟加载();
        //    Third_MEF延迟加载.ComponentPart();

        //    var strRes = Third_MEF延迟加载.Iperson.SayHello("李磊");
        //    var strRes2 = Third_MEF延迟加载.LazyIperson.Value.SayHello("Lilei");
        //    Console.WriteLine(strRes);
        //    Console.WriteLine(strRes2);
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

    public interface IPersons
    {
        string SayHello(string name);
    }

    //申明对象可导出
    [Export("Chinese_hello", typeof(IPersons))]
    public class Chineses : IPersons
    {
        public string SayHello(string name)
        {
            return "你好：" + name;
        }
    }
    //申明对象可导出
    [Export("America_hello", typeof(IPersons))]
    public class Americas : IPersons
    {
        public string SayHello(string name)
        {
            return "Hello:" + name;
        }
    }
}
