using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 种设计模式_23种.设计模式.模板模式
{
    class Program
    {
        static void Main(string[] args)
        {

            TemplatePattern tempC = new Chicken();
            tempC.Put();

            TemplatePattern tempE = new Elephant();
            tempE.Put();


            Console.ReadKey();
        }
    }

    public abstract class TemplatePattern
    {

        public void Put()
        {
            OpenBox();
            DoEnlargeBox();
            InsertBox();
            CloseBox();
        }

        ////具体方法，无需在子类中重新实现
        public void OpenBox()
        {
            Console.WriteLine("打开箱子\r\n");
        }

        public void CloseBox()
        {
            Console.WriteLine("关上箱子\r\n");
        }

//1.为了保证模板方法中调用的各种原语操作（抽象方法，具体方法，Hook方法）只能被模板方法调用，访问权限应为protected。

//2.尽量减少原语操作。以防客户端代码冗长。

//3.避免乱用模板方法，导致子类泛滥，应根据具体情况适时的使用。
        //Hook方法，扩大冰箱容量，此方法在子类中可选择实现。换句话说，只有在必要的时候才重写实现它
        virtual protected void DoEnlargeBox()
        {
        }
        public abstract void InsertBox();
    }

    public class Chicken : TemplatePattern
    {
        public override void InsertBox()
        {
            Console.WriteLine("放只鸡\r\n");
        }
    }

    public class Elephant : TemplatePattern
    {
        public override void InsertBox()
        {
            Console.WriteLine("放只大象\r\n");
        }
        protected override void DoEnlargeBox()
        {
            Console.WriteLine("扩大箱子1000倍\r\n");
        }
    }
}