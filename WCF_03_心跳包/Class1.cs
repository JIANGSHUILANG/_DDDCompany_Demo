using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_03_心跳包
{
    public class Class1
    {
        static void Main()
        {


        }
    }

    //InstanceContextMode：主要是管理上下文的实例，此处是single，也就是单体
    //ConcurrencyMode：    主要是用来控制实例中的线程数，此处是Multiple，也就是多线程
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class HeatBeaService : IHeatBeaService
    {
        static List<string> list = new List<string>();

        static object obj = new object();

        ///<summary>
        /// 此静态构造函数用来检测存活的Search个数
        ///</summary>
        static HeatBeaService()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 6000;
            timer.Elapsed += (sender, e) =>
            {
                lock (obj)
                {

                    foreach (var item in list)
                    {
                        ChannelFactory<IProduct> factory = null;

                        try
                        {
                            //File.ex
                            //当search存在的，心跳服务就要定时检测Search是否死掉，也就是定时的连接Search来检测。
                            factory = new ChannelFactory<IProduct>(new NetTcpBinding(SecurityMode.None), new EndpointAddress(item));
                            factory.CreateChannel();
                            factory.Close();
                            Console.WriteLine(item);
                        }
                        catch
                        {
                            list.Remove(item);
                            factory.Abort();
                            Console.WriteLine("\n当前时间：" + DateTime.Now + " ,存活的Search有：" + list.Count() + "个");
                        }
                    }
                }
                //最后统计下存活的search有多少个
                Console.WriteLine("\n当前时间：" + DateTime.Now + " ,存活的Search有：" + list.Count() + "个");
            };
            timer.Start();
        }


        public void AddSearch(string address)
        {
            if (!list.Contains(address))
            {
                list.Add(address);
                //search添加成功后就要告诉来源处，此search已经被成功载入。
                var client = OperationContext.Current.GetCallbackChannel<ILiveAddressCallback>();
                client.LiveAddress(address);
            }
        }


        public void GetService(string address)
        {
            System.Timers.Timer timer = new  System.Timers.Timer();
             timer.Interval = 1000;
             timer.Elapsed += (obj, sender) =>
             {
                 try
                 {
                     //这个是定时的检测IIS是否挂掉
                     var factory = new ChannelFactory<IServiceList>(new NetTcpBinding(SecurityMode.None),
                                                                    new EndpointAddress(address));
 
                     factory.CreateChannel().AddSearchList(list);
 
                     factory.Close();
 
                     timer.Interval = 10000;
                 }
                 catch (Exception ex)
                 {
                     Console.WriteLine(ex.Message);
                 }
             };
             timer.Start();
        }

    }
    //CallbackContract：这个就是Client实现此接口，方便服务器端通知客户端
    [ServiceContract(CallbackContract = typeof(ILiveAddressCallback))]
    public interface IHeatBeaService
    {
        ///<summary>
        /// 此方法用于Search启动后，将Search地址插入到此处
        ///</summary>
        ///<param name="address"></param>
        [OperationContract(IsOneWay = true)]
        void AddSearch(string address);

        ///<summary>
        /// 此方法用于IIS端获取search地址
        ///</summary>
        ///<param name="address"></param>
        [OperationContract(IsOneWay = true)]
        void GetService(string address);
    }

    public interface ILiveAddressCallback
    {
        [OperationContract(IsOneWay = true)]
        void LiveAddress(string address);
    }

}
