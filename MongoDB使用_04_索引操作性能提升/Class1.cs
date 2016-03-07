using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB使用_04_索引操作性能提升
{
    class Class1
    {
        static void Main()
        {
            //从算法上来说有5种经典的查找，具体的可以参见我的算法速成系列，这其中就包括我们今天所说的“索引查找”，如果大家对sqlserver比较了解
            //的话，相信索引查找能给我们带来什么样的性能提升吧。
            //往某个表中插入 10W条数据
           //for (var i = 0; i < 100000; i++){
           //    var rand = parseInt(i * Math.random());
           //    db.User.insert({"name":"jiang"+i,"age":i});
           //}
            //以上是没有创建索引的直接查询相当耗时
            //索引会降低CUD这三种操作的性能，因为这玩意需要实时维护

            //db.User.dropIndex("name_1_birthday_1") -->>操作User表name_1_birthday_1的索引
            //db.User.dropIndexes()                  -->>操作User表中所有的索引
            //db.User.getIndexes()                   -->>获取User表中所有的索引
           

            //1 .建立索引（ensureIndex）

            //db.User.ensureIndex({"name":1}) //给User表中name属性创建索引,创建索引后查询速度飞跃


            //2.性能分析函数（explain）

            //db.User.find({"name":"jiang"+10000}).explain()  查看性能


            //3.唯一索引（ensureIndex）

            //db.User.ensureIndex({"name":1},{"unique":true})
            //-->>再插入相同的name的值将报错db.User.insert({"name":"jiang2","age":2});



            //4.组合索引

            //有时候我们的查询不是单条件的，可能是多条件，比如查找出生在‘1989-3-2’名字叫‘jack’的同学，那么我们可以建立“姓名”和"生日“
            //的联合索引来加速查询
            //db.User.remove({})
            //db.User.insert({"name":"jack","birthday":"1989-10-01"})
            //db.User.insert({"name":"rose","birthday":"1990-08-08"})
            //db.User.insert({"name":"davie","birthday":"1981-12-16"})
            //db.User.insert({"name":"jason","birthday":"1990-10-05"})
            //db.User.insert({"name":"mike","birthday":"1989-10-01"})

            //db.User.ensureIndex({"name":1,"birthday":1})
            //db.User.ensureIndex({"birthday":1,"name":1})
            //以上两句执行会生成4个索引
            //db.User.find({"name":"mike","birthday":"1989-10-01"}).explain()

            //.hint({"name":1,"birthday":1}) 暴力执行 "name":1,"birthday":1 的这个索引
            //db.User.find({"name":"mike","birthday":"1989-10-01"}).hint({"name":1,"birthday":1}).explain()
        }
    }
}
