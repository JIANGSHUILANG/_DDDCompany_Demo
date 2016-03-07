using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB使用_03_高级操作游标聚合等
{
    class Class1
    {
        static void Main()
        {
            /********************************    Count    **********************************/
            //db.User.count()  -->> 查所有的个数

            //db.User.count({"age":{$gt:2}}) -->> 查所有 age>2 的个数



            /********************************    distinct    **********************************/

            //指定了谁，谁就不能重复
            //db.User.distinct("age") -->>输出结果 [27,30,33]


            /********************************    Group    **********************************/

            //db.Person.insert({"name":"zhaoliu","age":11})
            //db.Person.insert({"name":"yaoming","age":22})
            //db.Person.insert({"name":"zhanmusi","age":18})
            //db.Person.insert({"name":"kebi","age":30})
            //db.Person.insert({"name":"习近平","age":50})
            //db.Person.insert({"name":"李克强","age":50})

            //------------------>> key ： 这个就是分组的key，我们这里对年龄分组 。

            //------------------>>initial: 每组都分享一个”初始化函数“，特别注意：是每一组，比如这个的age=20的value的list分享一个initial函数，                                            age=22同样也分享一个initial函数。

            //------------------>>$reduce:这个函数的第一个参数是当前的文档对象，第二个参数是上一次function操作的累计对象，第一次为initial中的                                            {”perosn“：[]}。有多少个文档， $reduce就会调用多少次。


            //"$reduce":function(cur,prev){
            //prev.PersonName.push(cur.name);
            //}

            // db.Person.group({
            //"key":{"age":true},
            //"initial":{"PersonName":[]},
            //"$reduce":function(cur,prev){
            // prev.PersonName.push(cur.name);
            //}
            //})   -->> 我们通过age查看到了相应的name人员 ，年龄相同的人为一组


            //①：想过滤掉age>25一些人员。
            //②：有时PersonName数组里面的人员太多，我想加上一个count属性标明一下。

            //group有两个可选参数：condition 和 finalize
            //------------------>> condition : 过滤条件
            //------------------>> finalize  : 这个函数在每组文档执行完后，会触发此方法，那么在每组集合里面加上count也就是它的活了

            // db.Person.group({
            //      "key":{"age":true},                      //指定group的字段
            //      "initial":{"PersonName":[]},             //指定分组后放入的类型， [] 这里是数组，数组名字：PersonName
            //      "reduce":function(cur,prev){
            //              prev.PersonName.push(cur.name);  //上一次function操作的累计对象继续往PersonName数组里添加cur文档的name
            //              },
            //      "finalize":function(out){
            //              out.count=out.PersonName.length; //count属性
            //               },
            //      "condition":{"age":{$gt:25}}            //过滤条件
            //})



            /********************************    mapReduce   **********************************/

            //-------测试不可用 ???????
            //mapReduce : 是一种编程模型，用在分布式计算中，其中有一个“map”函数，一个”reduce“函数。
            //------------------>> map: 这个称为映射函数，里面会调用emit(key,value)，集合会按照你指定的key进行映射分组。
            //------------------>> reduce:这个称为简化函数，会对map分组后的数据进行分组简化，
                                          //注意：在reduce(key,value)中的key就是emit中的key，vlaue为emit分组后的emit(value)的集合，这里也就是很                                             多{"count":1}的数组。
            //db.Person.find()
            //map
            //function(){
            //emit(this.name,{count:1});
            //}
            //reduce
            //function(key,value){
            //var result={count:0};
            //for (int i = 0; i < value.length; i++)
            //{
            //    result.count += value[i].count;
            //}
            //return result;
            //}
            //db.Person.mapReduce(map,reduce,{"out":"collection"})
            //            从图中我们可以看到如下信息：
            //       result: "存放的集合名“；
            //       input:传入文档的个数。
            //       emit：此函数被调用的次数。
            //       reduce：此函数被调用的次数。
            //       output:最后返回文档的个数。
            //最后我们看一下“collecton”集合里面按姓名分组的情况。
            //db.collection.find()


            /********************************    游标   **********************************/

            //mongodb里面的游标有点类似我们说的C#里面延迟执行，比如：
            //var list=db.person.find();
            //针对这样的操作，list其实并没有获取到person中的文档，而是申明一个“查询结构”，等我们需要的时候通过
            //for或者next()一次性加载过来，然后让游标逐行读取，当我们枚举完了之后，游标销毁，之后我们在通过list获取时，
            //发现没有数据返回了。

            //var list = db.Person.find();
            //list.forEach(function(x){
            //print(x.name);
            //})

            //------------>>排序
            //db.Person.find().sort({"age":1}) -->>安年龄排序

            //------------>>分页排序
            //db.Person.find().sort({"age":1}).skip(2).limit(2); -->>先排序后，在按照排序的数据跳过2条取两条
        }
    }
}
