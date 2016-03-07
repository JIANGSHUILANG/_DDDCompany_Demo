using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer使用定时发推送消息
{

    class Class1
    {
        public delegate void Seeddel();
        static void Main()
        {

            //Timer使用线程激增 ：导致同一时间同时执行，解决办法，在时间执行之前timer.Stop()，时间完成之后再开启timer.Start()

            //我们知道Timer确实非常好用，因为里面有非常人性化的start和stop功能，在Timer里面还有一个Interval，就是用来设置时间间隔，然后时间间隔到了就会触发Elapsed事件

            //可以用Timer写一个Windows服务

            //System.Timers.Timer timer = new System.Timers.Timer();

            MyTimer timer = new MyTimer();
            timer.Interval = 1500;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
            Console.Read();

        }

        static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var temptimer = sender as MyTimer;

            temptimer.Stop(); //先停掉   --->>   线程激增的解决办法
            if (temptimer != null)
            {
                if (temptimer.queue.Count > 0)
                {
                    Thread.Sleep(new Random().Next(8000, 10000));
                    int queuecount = temptimer.queue.Dequeue();
                    Console.WriteLine("第-- {0} --条消息推送成功,当前时间：{1}", queuecount, DateTime.Now);
                    temptimer.Start();  //再启动
                }
            }
        }

    }

    public class MyTimer : System.Timers.Timer
    {
        public Queue<int> queue = new Queue<int>();
         
        public MyTimer()
        {
            for (int i = 0; i < 10000; i++)
            {
                queue.Enqueue(i);
            }
        }
    }
}
