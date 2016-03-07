using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB使用_10_错误解决
{
    public class Class1
    {
        static void Main()
        {
            //mongodb异常关闭后，再启动需要操作mongd.lock文件
            //解决方法：
            //---->>> 直接用360强力操作mongd.lock文件就好
            //1、操作%MONGO_HOME%/db下的.lock文件
            //2、输入命令 mongod --repair
            //3、重启mongoDB
            

        }
    }
}
