using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_01_Binding的使用_netMsmqBinding
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IOrder
    {
        //MSMQ被设计为：脱机访问
        //所以是  “单向模式”
        [OperationContract(IsOneWay = true)]
        void AddOrder(string order);
    }
}
