using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF_02_事物的使用;

namespace WCF_02_事物的使用_调用
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ChannelFactory<ISell>(new WSHttpBinding(), new EndpointAddress(@"http://localhost:8799/Sell/"));

            var sell = factory.CreateChannel();
            DTO_UserInfo userinfo = new DTO_UserInfo()
            {
                Name = "李四",
                Password = "666666"
            };

            DTO_Shop shop = new DTO_Shop()
            {
                ShopName = "男装",
                ShopUrl = "urlurlurl",
                UserID = 3
            };

            bool b = sell.Add(userinfo, shop);
            Console.WriteLine(b);
            Console.ReadKey();
            
        }
    }
}
