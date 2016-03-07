using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件和委托
{
    class Class2
    {
        static void Main()
        {
            //EventHandler:系统自带事件
            ICan c = new Can();

            //Print方法，传入的参数   “什么鬼” 在这里传入和操作
            c.ConsoleHandler += parms =>
            {
                Console.WriteLine(parms);
                return parms;
            };

            
            string str = c.Print("什么鬼");

            Console.ReadKey();
        }


    }

    public interface ICan
    {
        //List<string> list;  Gao ge jiba
        event Func<string, string> ConsoleHandler;
        string Print(string msg);
        void Writes();
    }

    public class Can : ICan
    {
        public static List<int> list;
        public event Func<string, string> ConsoleHandler;
        ~Can()
        {

        }

        public string Print(string msg)
        {
            Console.WriteLine("Print Start ......");
            string str = ConsoleHandler.Invoke(msg);
       
            Console.WriteLine("Print End ......");
            return str;
        }

        public void Writes()
        {
            throw new NotImplementedException();
        }
    }


}
