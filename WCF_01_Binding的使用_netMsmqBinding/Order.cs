using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WCF_01_Binding的使用_netMsmqBinding
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class Order : IOrder
    {
        public static object obj = new object();
        public void AddOrder(string order)
        {
            try
            {
                lock (obj)
                {
                    File.AppendAllText(@"E://Order.txt", order);
                    MessageQueue queue = new MessageQueue(@".\private$\myqueue");
                    Message message = new Message();
                    message.Label = "temp";
                    message.Body = order;
                    queue.Send(message);   //调试的时候消息队列中有数据，运行完之后就没有数据了
                    Console.WriteLine("已发送,当前线程:"+Thread.CurrentThread.ManagedThreadId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
