using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_01_Binding的使用
{
    public class console宿主
    {
        static void Main()
        {
            //项目开发中常用的三种绑定：
            //第一：wsHttpBinding，   这个binding可以认为是webservice的加强版WSE，设计的目的就是用于异构系统的交互（比如java）。

            //第二：netTcpBinding，   这个binding可以认为是remoting的加强版，设计的目的就是用于不同机器的.net 程序交互，

            //第三: netMsmqBinding,  这个binding可以认为是msmq的加强版本，设计目的就是脱机环境下不同机器的.net程序交互，确保信息不丢失。    MSMQ-->>消息队列


            //已在app.config配置好WCF为 wsHttpBinding 方式
            //     <endpoint address=""
            //          binding="wsHttpBinding"   
            //          contract="WCF_01_Binding的使用.IService">
            //</endpoint>
            using (ServiceHost host = new ServiceHost(typeof(Service)))
            {
                //HTTP 无法注册 URL http://+:1234/WCF_01Test/。进程不具有此命名空间的访问权限:报这个错，已管理员方式运行VS
                host.Open();
                Console.WriteLine("WCF已开启");
                Console.ReadKey();
            }


            //配置 netTcpBinding 方式 
            //只需要修改 app.config 两个地方：
            //   address="net.tcp://localhost:1111/WCF_01Test"    binding="netTcpBinding"  
            //      <endpoint address="net.tcp://localhost:1111/WCF_01Test"
            //          binding="netTcpBinding"   
            //          contract="WCF_01_Binding的使用.IService">
            //</endpoint>
            using (ServiceHost host = new ServiceHost(typeof(Service)))
            {
                host.Open();
                Console.WriteLine("WCF已开启");
                Console.ReadKey();
            }





        }
    }
}
