using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB使用_09_集群部署等其它
{
    class Class1
    {
        static void Main()
        {
            // cmd 命令指定到mongodb\bin 文件夹下：
            // show dbs   :查询所有的数据表


            //            1.  启动和停止MongoDB：

            //    执行mongod命令启动MongoDB服务器。mongod有很多可配置的选项，我们通过mongod --help可以查看所有选项，这里仅介绍一些主要选项：
            //    --dbpath：
            //    缺省情况下数据库的数据目录为/data/db。对于Windows平台，如果当前的可执行文件位于D盘，那么其缺省数据目录为D:\data\db。我们可以通过这个选项为服务程序重新指定数据目录。如果当前主机运行多个mongod，那么必须为每个服务程序指定不同的数据目录，因为当mongod启动成功之后，会在数据目录下创建一个mongod.lock的文件，该文件用于防止其它mongod进程数据该数据目录。如：
            //    mongod --dbpath=D:/data2/db

            //    --port
            //    缺省情况下的默认端口号是27017。同样当有多个mongod服务程序在同一台主机同时运行时，则需要为它们分别指定不同的监听端口。如：
            //    mongod --port=29017

            //    --fork
            //    以守护进程的方式运行MongoDB。

            //    --logpath
            //    指定日志输出路径，而不是输出到命令行。如果对文件夹有写权限的话，系统会在文件不存在时创建它。它会将已有文件覆盖掉，清除所有原来的日志记录。如果想保留原来的日志，还需要使用--logappend选项。如：
            //    /> mongod --logpath=D:\logdata\mylog.log
            //    all output going to: D:\logdata\mylog.log
            //    需要说明的是，对于上例，logdata目录必须被提前手工创建，否则mongod将执行启动失败。

            //    --config
            //    指定配置文件，用于加载命令行未指定的各种选项。如：
            //    mongod --config=D:\mydb.conf
            //    配置文件的示例内容如下：
            //    port = 29017
            //    fork = true   #这里的井号表示注释部分，对于fork这种命令行选项，需要用true来表示打开了。
            //    logpath = D:\mylog\db.log

            //    通常情况下，我们都是希望将mongodb server优雅的关闭。如果服务程序运行于前台，那么直接CTRL+C即可。如果是后台，那么可以通过SIGINT和SIGTERM信号来通知服务程序准备退出，服务器在收到信号后，会先妥善的安排退出前的数据和状态保存工作，如：正常的关闭当前的连接、将缓存中的数据刷新到磁盘等。在完成所有这些工作之后，服务器正常停止。如：
            //    /> pkill mongod
            //    /> pkill -2 mongod
            //    切记不要直接执行下面的命令:
            //    /> pkill -9 mongod
            //    该信号将会导致mongodb server强制性立即退出。
            //    除了上述方法之外，我们还可以通过mongo客户端工具通知服务器正常退出，如：
            //    > use admin
            //    switched to db admin
            //    > db.shutdownServer()

            //2、服务器状态监控：

            //    C:\Mine\ThirdParty\mongodb\bin>mongostat
            //    connected to: 127.0.0.1
            //    insert  query update delete getmore command flushes mapped  vsize    ... ...
            //     0      0      0      0       0       1       0     0m   100m    ... ...
            //     0      0      0      0       0       1       0     0m   100m    ... ...
            //     0      0      0      0       0       1       0     0m   100m    ... ...
            //     0      0      0      0       0       1       0     0m   100m    ... ...
            //     0      0      0      0       0       1       0     0m   100m    ... ...
            //     0      0      0      0       0       1       0     0m   100m    ... ...
            //     0      0      0      0       0       1       0     0m   100m    ... ...
            //     0      0      0      0       0       1       0     0m   100m    ... ...
        }
    }
}
