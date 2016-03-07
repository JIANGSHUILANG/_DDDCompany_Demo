using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield用法
{
    public class Class1
    {
        static void Main()
        {
            var list = new List<string>();
            list.Add("China");
            list.Add("China");
            list.Add("China");
            list.Add("China");
            list.Add("English");
            list.Add("Japan");
            list.Add("Franch");
            var reslut = Get(list.AsEnumerable());
            Console.WriteLine(reslut.Count());
            Console.ReadKey();
        }
        static IEnumerable<string> Get(IEnumerable<string> tempstrs)
        {
            foreach (var item in tempstrs)
            {
                if (item == "China")
                    yield return item;
            }
        }
    }

    class TestClass : global::Yield用法.Class1
    {
    
    }

    public abstract class Base
    {
     
    }

    public class Children : Base
    { 
    
    }
}
