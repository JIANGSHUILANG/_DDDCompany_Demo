using MongoDB;
using MongoDB.Attributes;
using MongoDB.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Linq;
namespace MongoDB使用_08_驱动实践Csharp使用
{
    class Test
    {
        static void Main()
        {
            //官方驱动：https://github.com/mongodb/mongo-csharp-driver/downloads。下载后，还提供了一个酷似msdn的帮助文档。

            //samus驱动：https://github.com/samus/mongodb-csharp/downloads。 //好用 提供丰富的linq操作
            //samus文档：https://github.com/samus/mongodb-csharp/blob/master/examples/Simple/Main.cs


            //http://www.yiibai.com/mongodb/mongodb_create_database.html  //MongoDB文档 ！！！很全


            MongoHelper<Person> helper = new MongoHelper<Person>();

            #region 插入数据测试 OK

            //for (int i = 0; i < 1000; i++)
            //{
            //    helper.Insert(new Person()
            //    {
            //        ID = Guid.NewGuid().ToString(),
            //        Name = "Mike" + i,
            //        Age = i,
            //        CreateTime = DateTime.Now
            //    });
            //}
            //Console.WriteLine("Insert OK ...");

            #endregion

            #region 查询数据测试 OK

            //int pagecount;
            //var list = helper.LoadPageEnities(1, 10, out pagecount, c => c.Name.Contains("8"), c => c.CreateTime, true);
            //list.ForEach(c =>
            //{
            //    Console.WriteLine(c.Name + "====" + c.CreateTime);
            //});
            //Console.WriteLine(pagecount);

            //var per = helper.Find(c => c.Name == "Mike1");

            #endregion

            #region 修改数据测试 OK

            //var model = helper.Find(c => c.Name == "Mike1");
            //model.Age = 10000;
            //helper.Update(model, c => c.Name == "Mike1");
            //Console.WriteLine("修改成功");

            #endregion

            #region 操作数据测试 OK

            //helper.Delete(c => c.Name == "Mike1");
            //Console.WriteLine("操作成功");

            #endregion


            Console.ReadKey();
        }
    }
    public class Person
    {
        //MongoAlias特性表示取别名，这里的ID值将会覆盖掉数据库自动生成的_id
        [MongoAlias("_id")]
        public string ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime CreateTime { get; set; }
    }

    public class MongoHelper<T> where T : class,new()
    {
        string connectionString = string.Empty;
        string databaseName = string.Empty;
        string collectionName = string.Empty;
        static MongoHelper<T> mongodb;

        public MongoHelper()
        {
            connectionString = "Server=127.0.0.1:27017";
            databaseName = "MyCharpData";
            collectionName = "person";
        }

        #region   实现 Linq 查询的映射配置

        public MongoConfiguration configuration
        {
            get
            {
                var config = new MongoConfigurationBuilder();
                config.Mapping(mapping =>
                {
                    mapping.DefaultProfile(c =>
                    {
                        c.SubClassesAre(t => t.IsSubclassOf(typeof(T)));
                    });
                    mapping.Map<T>();
                    mapping.Map<T>();
                });
                config.ConnectionString(connectionString);
                return config.BuildConfiguration();
            }
        }

        #endregion

        #region CURD操作


        public void Insert(T t)
        {
            using (Mongo mongo = new Mongo(configuration))
            {
                try
                {
                    mongo.Connect();
                    var db = mongo.GetDatabase(databaseName);
                    var collection = db.GetCollection<T>(collectionName);
                    collection.Insert(t, true);
                    mongo.Disconnect();
                }
                catch (Exception ex)
                {
                    mongo.Disconnect();
                    throw;
                }
            }
        }

        public void Update(T t, Expression<Func<T, bool>> wherelamda)
        {
            using (Mongo mongo = new Mongo(configuration))
            {
                try
                {
                    mongo.Connect();
                    var db = mongo.GetDatabase(databaseName);
                    var collection = db.GetCollection<T>(collectionName);
                    collection.Update<T>(t, wherelamda, true);
                    mongo.Disconnect();
                }
                catch (Exception ex)
                {
                    mongo.Disconnect();
                    throw;
                }
            }
        }

        public List<T> LoadPageEnities<S>(int pageIndex, int pageSize, out int pageCount, Expression<Func<T, bool>> wherelamda, Expression<Func<T, S>> orderLamda, bool Asc)
        {
            pageCount = 0;
            using (Mongo mongo = new Mongo(configuration))
            {
                try
                {
                    mongo.Connect();

                    var db = mongo.GetDatabase(databaseName);

                    var collection = db.GetCollection<T>(collectionName);


                    pageCount = collection.Linq().ToList().Count(); //消耗性能  collection.Count()  MongoDB这个方法不能用

                    IQueryable<T> templist = null;
                    if (orderLamda != null)
                    {
                        if (Asc)
                        {
                            templist = collection.Linq().Where(wherelamda).OrderBy(orderLamda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                        }
                        else
                        {
                            templist = collection.Linq().Where(wherelamda).OrderByDescending(orderLamda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                        }
                    }
                    else
                        templist = collection.Linq().Where(wherelamda).Skip((pageIndex - 1) * pageSize).Take(pageSize);

                    var list = templist.ToList();

                    mongo.Disconnect();

                    return list;
                }
                catch (Exception ex)
                {
                    mongo.Disconnect();
                    throw;
                }
            }
        }

        public T Find(Expression<Func<T, bool>> wherelamda)
        {
            using (Mongo mongo = new Mongo(configuration))
            {
                try
                {
                    mongo.Connect();

                    var db = mongo.GetDatabase(databaseName);

                    var collection = db.GetCollection<T>(collectionName);

                    T entity = collection.Linq().FirstOrDefault(wherelamda);

                    mongo.Disconnect();

                    return entity;
                }
                catch (Exception ex)
                {
                    mongo.Disconnect();
                    throw;
                }
            }
        }

        public void Delete(Expression<Func<T, bool>> wherelamda)
        {
            using (Mongo mongo = new Mongo(configuration))
            {
                try
                {
                    mongo.Connect();
                    var db = mongo.GetDatabase(databaseName);
                    var collection = db.GetCollection<T>(collectionName);

                    //这个地方要注意，一定要加上T参数，否则会当作object类型处理导致操作失败
                    collection.Remove<T>(wherelamda);

                    mongo.Disconnect();

                }
                catch (Exception ex)
                {
                    mongo.Disconnect();
                    throw;
                }
            }
        }
        #endregion
    }
}
