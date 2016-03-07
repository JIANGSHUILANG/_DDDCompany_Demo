using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_02_事物的使用
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface ISell
    {
        [OperationContract(Name = "AddUser")]
        bool Add(DTO_UserInfo user, out int userID);

        [OperationContract(Name = "AddShop")]
        bool Add(DTO_Shop shop, out int shopID);

        [OperationContract]
        bool Add(DTO_UserInfo user, DTO_Shop shop);
    }
}
