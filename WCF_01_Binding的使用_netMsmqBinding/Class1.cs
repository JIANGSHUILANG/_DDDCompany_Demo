using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_01_Binding的使用_netMsmqBinding
{
    public class Class1
    {
        public static void Main()
        {
            //netMsmqBinding  -->> Msmq  MSMQ 消息队列
            string serverpath = "system.serviceModel/client";
            object obj = ConfigurationManager.GetSection(serverpath);
            string queueName = System.Configuration.ConfigurationManager.AppSettings["queueName"];

            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true); //true 创建事物性队列

            //在服务 Order 实现的协定列表中找不到协定名称 "IMetadataExchange"。将 ServiceMetadataBehavior 添加到配置文件或直接添加到 ServiceHost，以启用对该协定的支持 注释掉app.config  -->>
            //<endpoint address="mex" binding="mexHttpBinding"  contract="IMetadataExchange" />
            ServiceHost host = new ServiceHost(typeof(Order));

            host.Open();
            Console.WriteLine("WCF已开启");
            Console.ReadKey();




        }
    }
}
