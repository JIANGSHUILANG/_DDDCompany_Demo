using BlogSytemManager.Repository.EFContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSytemManager.Test
{
    public class Class1
    {
        static void Main()
        {

            using (AfterManageContext context = new AfterManageContext())
            {
                var temp = context.Menu.Where(c => true).ToList();
               

            }
            Console.ReadKey();
        }
    }

    public class Test
    {
        public void Hello()
        {

        }
    }
}
