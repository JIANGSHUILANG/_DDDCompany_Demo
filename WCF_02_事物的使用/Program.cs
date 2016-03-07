using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_02_事物的使用
{
    class Program
    {
        static void Main(string[] args)
        {
            //实现接口的方法上加：

            //[OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
            //TransactionScopeRequired： 告诉ServiceHost自托管服务，进入我的方法，必须给我加上事务。
            //TransactionAutoComplete:   方法执行中，如果没有抛出异常，则自动提交。

            using (ServiceHost host = new ServiceHost(typeof(Sell)))
            {
                host.Open();

                Console.WriteLine("WCF服务已开启");

                Console.ReadKey();  //  Console.ReadKey()一定要写在 using{}里面
              
            }
           
            
        }
    }

    [DataContract]
    public class DTO_Shop
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public string ShopName { get; set; }
        [DataMember]
        public string ShopUrl { get; set; }
    }
    [DataContract]
    public class DTO_UserInfo
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Password { get; set; }
    }


}
