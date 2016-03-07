using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件和委托
{
    class Class1
    {
        static void Main1()
        {
            //这里整个执行过程如下：

            //首先实例化一个Mouse,Mouse构造函数中添加了  Cat.Cry  中的事件，事件执行的方法是  Run()
            //Console.WriteLine("Mouse : I will Die") 它不会事先执行
            //当实例化一个Cat,调用  OnCry() 方法时，判断 Cry 是否为空，（Cry 事件在Mouse构造函数中已经添加Run()方法 已经不为空             // Cry 时间不为空 Cry.Invoke() 执行 Cry 添加的方法

            Mouse mouse = new Mouse();

            Cat cat = new Cat();

            cat.OnCry();

            Console.ReadKey();
        }
    }

    public delegate void CryHandler(); //定义一个委托

    public class Mouse//
    {
        public Mouse()
        {
            Cat.Cry += new CryHandler(Run);
        }

        public void Run()
        {
            Console.WriteLine("Mouse : I will Die");
        }
    }

    public class Cat  //
    {
        public static event CryHandler Cry;

        public Cat()
        {
            Console.WriteLine("Cat : Miao Miao");
        }

        public void OnCry()
        {
            //Cry = null;
            if (Cry != null)
            {
                Cry.Invoke();
            }
        }
    }
}
