using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF_01_Binding的使用_netMsmqBinding;

namespace WCF_01_Binding的使用_netMsmqBinding_调用
{
    public class Class1
    {
        static void Main()
        {
            //客户端代码：
            //新建一个Console程序作为客户端来对MSMQ进行测试，这次我们通过“信道”的方式生成实例。
            //  ①： 让Host服务Off Line，我们插入100条Order，看msmq有什么反应。

            //不添加服务引用也可以可以使用IOrder的方法，但是不能往消息队列插数据
            var factory = new ChannelFactory<IOrder>
                (
                new NetMsmqBinding(NetMsmqSecurityMode.None),
                new EndpointAddress(@"net.msmq://localhost/private/myqueue")
                );
            IOrder order = factory.CreateChannel();
            for (int i = 0; i < 10; i++)
            {
                order.AddOrder(string.Format("订单：{0}，创建时间：{1}\r\n", i, DateTime.Now));
                Console.WriteLine("已写入 {0} 条数据", i);
            }

            Console.ReadKey();
        }
    }
}
