using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB使用_02_细说增删改查
{
    class Test
    {
        static void Main()
        {

            //MongoDB 使用的JS语法，所以在 MongoDB是使用javascript也可以。

            //JSON里面Value可能是“字符串”，可能是“数组”，又有可能是内嵌的一个JSON对象，相同的方式也适合于BSON。
            //常见的插入操作也就两种形式存在：“单条插入”和“批量插入”。


            /********************************    增    **********************************/

            //Insert 单条插入：（多条插入开个循环）
            //var sigin={"name":"jiang","password":"123456","age":27,"address":{"province":"jiangxi","city":"jingdezhen"},"love":["apple","org"]}
            //db.User.insert(sigin)

            //sigin.name="zhangfei"
            //sigin.password="123456"
            //sigin.age=10
            //sigin.address={"province":"NewYork","city":"MenDaNa"}
            //sigin.love=["Women","girl"]
            //db.User.insert(sigin) -->>就重新又插入了一条数据


            /********************************    查询    **********************************/

            //Find 查询：  //"$gt", "$gte", "$lt", "$lte", "$ne" ,  "$or", "$in"，"$nin"
            //①： >, >=, <, <=, !=, =。
            //②：And，OR，In，NotIn

            // $gt 对应  >

            // $lt 对应  <

            // $ne 对应  !=


            // age > 10
            //db.User.find({"age":{$gt:10}})

            //相当于查询    name="jiang" && address.city="jingdezhen" 同时
            //db.User.find({"name":"jiang","address.city":"jingdezhen"})


            //  address.city="jingdezhen" ||  address.city="MenDaNa"  或者
            //db.User.find({$or:[{"address.city":"jingdezhen"},{"address.city":"MenDaNa"}]})


            // address.city in("jingdezhen","MenDaNa")
            //db.User.find({"address.city":{$in:["jingdezhen","MenDaNa"]}})


            // address.city not in("jingdezhen")
            //db.User.find({"address.city":{$nin:["jingdezhen"]}})




            //正则表达式：这玩意威力很强的。
            //db.User.find({"name":/^j/,"name":/g$/})  -->>查询name以j开头同时name以g结尾的
            //db.User.find({"name":/^[jzg]/}) -->>查询name以 j  z  g开头的


            //$where：mongodb 大招
            //db.User.find({$where:function(){return this.name=="jiang"}})-->>find name="jiang"

            /********************************    改    **********************************/

            //var model=db.User.findOne({"name":"jiang"})
            //model.age=2
            //db.User.update({"name":"jiang"},model)  -->> update  jiang's age = 2 (把整体查询出来了再更改，麻烦)

            // $inc  修改器  每次修改会在原有的基础上自增$inc指定的值，如果“文档”中没有此key，则会创建key，
            //如果name为jiang的这条数据中的age为3,然后再执行下面这条语句则age的值为30
            //db.User.update({"name":"jiang"},{$inc:{"age":27}}) -->>原基础上增加 27

            //$set 修改器        把age的值更改为27
            //db.User.update({"name":"jiang"},{$set:{"age":27}})


            //upsert         操作upsert操作就是说：如果我没有查到，我就在数据库里面新增一条，其实这样也有好处，就是避免了我在数据库里面判断是                update还是add操作，使用起来很简单将update的第三个参数设为true即可。

            //db.User.update({"name":"Michael Jackson"},{$set:{"age":33}},true)


        }
    }
}
