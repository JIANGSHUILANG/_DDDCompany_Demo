using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB使用_01_安装和简单增删改查
{
     class Test
    {
         static void Main()
         {
             //https://www.mongodb.org/downloads#production    MongoDB偶数为稳定版本
             //32bit的mongodb最大只能存放2G的数据，64bit就没有限制

             //MongoDB存放数据是采用键值对形式：Key,Value

             //D:\mongodb下新建newdata文件夹存放数据
             //cmd -->> 指定那个磁盘 如 D:-->>cd D:\mongodb\bin  回车(指定mongodb的安装路径)-->>mongod --dbpath=D:\mongodb\newdata (指定放数据的文件夹)
             //mongodb采用27017端口，那么我们就在浏览器里面键入“http://localhost:27017/”

             //cmd -->> 指定那个磁盘 如 D:-->>cd D:\mongodb\bin  回车 -->>输入 mongo （查看版本信息）(打开shell，其实这个shell就是mongodb的客户端)


           //错误： 2014-07-25T11:00:48.634+0800 warning: Failed to connect to 127.0.0.1:27017, reason: errno:10061 由于目标计算机积极拒绝，无法连接。
             //解决方案：在安装mogoDB的文件夹下，新建一个 mongo.config 文件，在文件中输入：
            //1.
            // ##数据文件
            //dbpath=E:\ruanjian\MongoDB\data
 
            //##日志文件
            //logpath=E:\ruanjian\MongoDB\log\mongo.log

            //2. 新建一个data文件夹

            //3.新建一个log文件夹，文件夹中新建一个mongo.log文件（空文件）
            //mongod.exe --config E:\ruanjian\MongoDB\mongo.config



             //大意是：如果您运行的是任何版本的Windows Server 2008 R2或Windows 7，请安装修复程序来解决一个内存映射文件在Windows的问题。
//             2016-03-08T12:56:05.689+0800 I CONTROL  Hotfix KB2731284 or later update is not installed, will zero-out data files
//MongoDB shell version: 3.0.6
//connecting to: test
//2016-03-08T12:56:06.845+0800 W NETWORK  Failed to connect to 127.0.0.1:27017, re
//ason: errno:10061 由于目标计算机积极拒绝，无法连接。
//2016-03-08T12:56:06.848+0800 E QUERY    Error: couldn't connect to server 127.0.
//0.1:27017 (127.0.0.1), connection attempt failed
//    at connect (src/mongo/shell/mongo.js:179:14)
//    at (connect):1:6 at src/mongo/shell/mongo.js:179
//exception: connect failed


//             




             //insert:  这里就取集合名为“Person”，要注意的就是文档是一个json的扩展（Bson)形式。如下插入两条数据
             //db.Person.insert({"name":"zhangsan","age":20})
             //db.Person.insert({"name":"li","age":15})       


             //find:  查询
             //① “_id"： 这个字段是数据库默认给我们加的GUID，目的就是保证数据的唯一性。 
             //② 严格的按照Bson的形式书写文档，不过也没关系，错误提示还是很强大的。
             //db.Person.find() 查询全部数据 (区分大小写)
             //db.Person.find({"name":"lisi"})  -->>根据name：lisi 来查询数据


             //update: update方法的第一个参数为“查找的条件”，第二个参数为“更新的值”
             //db.Person.update({"name":"zhangsan"},{"name":"王五"})-->>把name为zhangsan的数据改为：lisi了，而且age:20的数据也没了
             //修改后的结果： "_id" : ObjectId("564bda8174cc486141ee1f45"), "name" : "王五" }

             //remove:   操作中如果不带参数是全部操作
             //db.Person.remove()
             //db.Person.remove({"name":"lisi"})-->>操作单个数据

             //remove needs a query  报这个错误时，如下即OK： db.Person.remove({})
         }
    }
}
