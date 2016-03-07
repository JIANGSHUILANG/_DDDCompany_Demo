using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace 消息队列
{
    //public class BaseMessage:Message
    //{ 
    
    //}
    //public delegate void MessageQueueEventNotifyHandler(BaseMessage message);

    //public class MessageQueue : Queue<BaseMessage>
    //{
    //    public static MessageQueue GlobalQueue = new MessageQueue();

    //    private MessageQueueEventNotifyHandler messageNotifyEvent;
    //    public event MessageQueueEventNotifyHandler MessageNotifyEvent
    //    {
    //        add
    //        {
    //            this.messageNotifyEvent += value;
    //        }

    //        remove
    //        {
    //            if (this.messageNotifyEvent != null)
    //            {
    //                this.messageNotifyEvent -= value;
    //            }
    //        }
    //    }

    //    private Timer timer = new Timer();
    //    public MessageQueue()
    //    {
    //        this.timer.Interval = 5000;
    //        this.timer.Elapsed += Notify;
    //        this.timer.Enabled = true;
    //    }
    //    private void Notify(object sender, ElapsedEventArgs e)
    //    {
    //        lock (this)
    //        {
    //            if (this.Count > 0)
    //            {
    //                //this.messageNotifyEvent.GetInvocationList()[0].DynamicInvoke(this.Dequeue());
    //                var message = this.Dequeue();
    //                this.messageNotifyEvent(message);
    //            }
    //        }
    //    }

        
    //}
}
