using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB使用_05_主从复制
{
    class Class1
    {
        static void Main()
        {
            //http://www.cnblogs.com/huangxincheng/archive/2012/03/04/2379755.html
           
            //ql server能够做到读写分离，双机热备份和集群部署，当然mongodb也能做到，实际应用中我们不希望数据库采用单点部署，如果碰到数据库宕机               或者被毁灭性破坏那是多么的糟糕


            /*************************    主从复制    **************************/

            //一台主服务器 -->>两台从服务器
            //<1>  数据备份。
            //<2>  数据恢复。
            //<3>  读写分离。

            //实际引用中是多台服务器部署，现在演示在一台机器上实践
            //第一步：我们把mongodb文件夹放在D盘和E盘G盘，模拟放在多服务器上。
            //第二步：启动D盘上的mongodb，把该数据库指定为主数据库，其实命令很简单：>mongodb --dbpath='XXX' --master，端口还是默认的27017.
            //第三步：同样的方式启动E盘上的mongodb，指定该数据库为从属数据库，命令也很简单，当然我们要换一个端口，比如：8888。
            //        source 表示主数据库的地址。
            //        >mongod --dbpath=xxxx --port=8888 --slave --source=127.0.0.1:27017
           // 第四步：从图中的红色区域我们发现了一条：“applied 1 operations"这样的语句，并且发生的时间相隔10s，也就说明从属数据库每10s
                     //就向主数据库同步数据，同步依据也就是寻找主数据库的”OpLog“日志，可以在图中红色区域内发现”sync_pullOpLog“字样。
                     //接下来我们要做的就是测试，惊讶的发现数据已经同步更新，爽啊。


            /*************************    副本集    **************************/
            //http://www.cnblogs.com/huangxincheng/archive/2012/03/04/2379755.html
      // <1>:  该集群没有特定的主数据库。
      // <2>:  如果哪个主数据库宕机了，集群中就会推选出一个从属数据库作为主数据库顶上，这就具备了自动故障恢复功能，很牛X的啊。
               //好，我们现在就来试一下，首先把所有的cmd窗口关掉重新来，清掉db下的所有文件

            //第一步:  既然我们要建立集群，就得取个集群名字，这里就取我们的公司名BOBO, --replSet表示让服务器知道BOBO下还有其他数据库，
                      //这里就把D盘里面的mongodb程序打开，端口为2222。指定端口为3333是BOBO集群下的另一个数据库服务器。
                      // D:
                      // cd  D:\mongodb\bin  --dbpath=D:\mongodb\newdata --port=2222 --replSet BOBO/127.0.0.1:3333
        }
    }
}
