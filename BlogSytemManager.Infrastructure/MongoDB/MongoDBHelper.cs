using MongoDB;
using MongoDB.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Linq;
namespace BlogSytemManager.Infrastructure.MongoDB
{

    public class MongoDBHelper<T> where T : class,new()
    {
        string connectionString = string.Empty;
        string databaseName = string.Empty;
        string collectionName = string.Empty;
        static MongoDBHelper<T> mongodb;

        public MongoDBHelper()
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
