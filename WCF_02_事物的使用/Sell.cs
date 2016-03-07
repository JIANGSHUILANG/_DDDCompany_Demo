using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_02_事物的使用
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class Sell : ISell
    {

        public bool Add(DTO_UserInfo user, out int userID)
        {
            using (CodeFirstTempEntities db = new CodeFirstTempEntities())
            {
                bool Flag = false;
                try
                {
                    UserInfo userinfo = new UserInfo()
                    {
                        Name = user.Name,
                        Password = user.Password
                    };
                    db.UserInfo.Add(userinfo);
                    Flag = db.SaveChanges() > 0;
                    userID = userinfo.ID;
                }
                catch
                {
                    userID = 0;
                    throw;
                }
                return Flag;
            }
        }

        public bool Add(DTO_Shop shop, out int shopID)
        {
            using (CodeFirstTempEntities db = new CodeFirstTempEntities())
            {
                bool Flag = false;
                try
                {
                    Shop model = new Shop()
                    {
                        ShopName = shop.ShopName,
                        ShopUrl = shop.ShopUrl,
                        UserID = shop.UserID
                    };
                    db.Shop.Add(model);
                    Flag = db.SaveChanges() > 0;
                    shopID = model.ID;
                }
                catch
                {
                    shopID = 0;
                    throw;
                }
                return Flag;
            }
        }

        //不知道有没有卵用 !!!!!!
        //TransactionScopeRequired： 告诉ServiceHost自托管服务，进入我的方法，必须给我加上事务。
        //TransactionAutoComplete:   方法执行中，如果没有抛出异常，则自动提交。
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public bool Add(DTO_UserInfo user, DTO_Shop shop)
        {
            using (CodeFirstTempEntities db = new CodeFirstTempEntities())
            {
                bool Flag = false;

                int userID;
                int shopID;

                if (Add(user, out userID))
                {
                    if (Add(shop, out shopID))
                    {
                        Flag = true;
                    }
                }

                return Flag;
            }
        }
    }
}
