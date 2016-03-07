using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 并行编程.EFContext;

namespace 并行编程
{
    class Test
    {
        private static readonly ConcurrentDictionary<string, dynamic> DIC = new ConcurrentDictionary<string, dynamic>();
        private static readonly ConcurrentQueue<dynamic> queue = new ConcurrentQueue<dynamic>();
        static void Main()
        {
            using (TestEntities ef = new TestEntities())
            {
                #region 传入EF对象

                //Task task = Task.Factory.StartNew(x =>
                //{
                //    Role role = new Role() { Role_Name = "我擦" };
                //    ef.Role.Add(role);
                //    int i = ef.SaveChanges();
                //    return i;
                //}, ef);

                #endregion

                #region ConcurrentDictionary  queue 使用

                SetDataList(ef.Role.Where(c => true));

                Task<dynamic> task = Task.Factory.StartNew<dynamic>(() =>
                {
                    return queue.FirstOrDefault();
                });

                dynamic first = task.Result;

                #endregion

                //Console.Write(DIC.Count);
            }

           
            Console.ReadKey();

        }
  

        private static void SetDataList(IQueryable<Role> roleList)
        {
            var list = roleList.ToList();
            foreach (var item in list)
            {
                DIC.TryAdd(item.Role_Name, new { ID = item.ID, Name = item.Role_Name, CreateTime = item.CreateTime });
            }

            foreach (var item in DIC)
            {
                dynamic temp = default(dynamic);
                DIC.TryGetValue(item.Key, out temp);
                queue.Enqueue(temp);
            }
        }


    }
}
