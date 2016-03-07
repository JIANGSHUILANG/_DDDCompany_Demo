using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using 正则表达式.temp;
using System.Data.Objects;
using System.IO;
using System.Linq.Expressions;
using BlogSytemManager.Infrastructure.ExpressionHelper;
using System.Reflection;

namespace 正则表达式
{
    public enum EnumInsert_Del_Edit_Audit
    {
 
        Delete,
        Edit,
        Audit
    }
    class Class1
    {
        static void Main()
        {

            //Console.WriteLine(EnumInsert_Del_Edit_Audit.Create.ToString());

            Regex regex = new Regex("[0-9]+");

            Console.WriteLine(regex.IsMatch("15262604760"));
            Console.WriteLine(regex.IsMatch(""));
            Console.ReadKey();
            //var reg = new Regex("[/+-]");
            //string str = "abcde-";
            //var b = reg.IsMatch(str);

            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Add("dddd","1111111111");
            //string str= JsonConvert.SerializeObject(dic);
            //Console.Write(str);

            //SeeSee see = new SeeSee();
            //see._Console_();


            //SeeSee see1 = new SeeSee();
            //see1._Console_();

            //http://localhost:7911/UserInfoService.svc
            //temp.UserInfoServiceClient client = new temp.UserInfoServiceClient();
            //var temp = client.GetAllUserInfo();
            //var temp = client.DeleteUserInfos(new string[] { "11", "14" });
            //client.DeleteUserInfoById(11);
            //client.DeleteUserInfoById(11);
            //var x = client.GetUserInfoById(1);
            //x.Email = "9999@qq.com";
            //bool b = client.UpdateUserInfo(x);

            //Expression<Func<UserInfoObject, bool>> wherelamda = c => true;
            //Expression<Func<UserInfoObject, int>> orderlamda = c => c.ID;

            //Roleservice.RoleServiceClient client = new Roleservice.RoleServiceClient();

            //Roleservice.RoleObject obj = new Roleservice.RoleObject()
            //  {
            //      RoleName = "超级管理员",
            //      Remark = "To Manager",
            //      DelFlag = 1,
            //      RoleType = 2,
            //      SubTime = DateTime.Now
            //  };
            //bool b = client.CreateRole(obj);
            //var allrole = client.GetAllRole();

            //var onerole = client.GetRoleById(1);

            //client.DeleteRoleById(2);

            //var temp = client.GetRoleById(1);
            //temp.Remark = "给谁用";
            //temp.SubTime = DateTime.Now;
            //client.UpdateRole(temp);


            //SSS(null);
            //var list = client.GetAllUserInfo();
            Console.ReadKey();

        }

        static void SSS(string[] ids = null)
        {
            if (ids == null)
            {
                Console.WriteLine("null");
            }
        }

    }

    public class SeeSee
    {
        //静态构造函数就只执行一次

        static List<string> list = new List<string>();

        static int i = 0;

        static SeeSee()
        {
            i++;
            Console.WriteLine("Run GOU ZAO HAN SHU ...." + i);
        }

        public void _Console_()
        {
            Console.Write("Run ....");
        }
    }
}
