using BlogSytemManager.Repository.EFContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSytemManager.Repository
{
    class Test
    {
        static void Main()
        {
           
            //enable-migrations -force

            //未应用自动迁移，因为自动迁移会导致数据丢失。
            // Add-Migration Initial
            //Update-Database -Verbose



            //在Code First 创建函数
            //1.Add-Migration AddFnIsPaid  -- 先添加
            using (AfterManageContext context = new AfterManageContext())
            {
                var temp = context.Menu.Where(c => true).ToList();
                
            }
            Console.ReadKey();
        }
    }
}
