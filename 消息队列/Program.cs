using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace 消息队列
{
    class Program
    {
        static void Main(string[] args)
        {
            //消息队列用于计算机之间传递数据的队列。
            //引用  System.Messaging.dll

            //CreateMessageQueue("MytestMessage");


            //for (int i = 0; i < 30000; i++)
            //{
            //    MSMQModel model = new MSMQModel()
            //    {
            //        Name = "Jiang" + i,
            //        CreateTime = DateTime.Now
            //    };
            //    InserMessageQueue("MytestMessage", model);
            //}

            //var list = GetMessageQueue("MytestMessage") as List<MSMQModel>;

            //DeleteMessageQueue("MytestMessage");



            //var temp = GetMessageQueueBy_Id("MytestMessage", @"031358f8-907c-4361-81b6-8c5e4c5cc77b\313") as MSMQModel;


            var list = (List<MSMQModel>)GetMessageQueueReceive("MytestMessage");

            Console.ReadKey();
        }

        static void CreateMessageQueue(string name)
        {
            MessageQueue queue = null;
            if (!MessageQueue.Exists(".\\private$\\" + name))
            {
                queue = MessageQueue.Create(".\\private$\\" + name);
                queue.Label = "学习使用";
                Console.WriteLine(name + ":消息队列创建完成");
            }
            else
            {
                Console.WriteLine("系统已存在此消息队列");
            }
        }

        static void InserMessageQueue(string name, MSMQModel model)
        {
            MessageQueue queue = new MessageQueue(".\\private$\\" + name);

            System.Messaging.Message message = new Message();
            message.Label = model.Name;
            message.Body = model;
            queue.Send(message);
            Console.Write("插入数据到队列成功");
        }

        static void DeleteMessageQueue(string name)
        {
            MessageQueue.Delete(".\\private$\\" + name);

            Console.WriteLine(name + ":操作完毕");
        }

        /// <summary>
        /// 获取一条数据之后，计算机中队列数据就会少一条
        ///这个也可以被看做是单独操作一条数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        static object GetMessageQueueBy_Id(string name, string Id)
        {
            MessageQueue queue = new MessageQueue(".\\private$\\" + name);
            Message message = queue.ReceiveById(Id);
            var fomatter = new System.Messaging.XmlMessageFormatter(new Type[] { typeof(MSMQModel) });
            message.Formatter = fomatter;
            return (MSMQModel)message.Body;
        }

        /// <summary>
        /// 这只是取出数据放入内存中，而计算机中的队列数据仍存在
        /// 要全部取出并操作计算机中的队列则使用 Receive
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static object GetMessageQueue(string name)
        {
            List<MSMQModel> list = new List<MSMQModel>();
            MessageQueue queue = new MessageQueue(".\\private$\\" + name);

            //GetAllMessages方法领取所有消息，把它们保存在当地内存中；而GetMessageEnumerator2方法只领取当前消息在本地保存，在调用MoveNext时才领取下一条消息。下面这条语句举例说明了GetMessageEnumerator2方法的用法。
            Console.WriteLine(name + "--队列中共有：" + queue.GetAllMessages().Length + "条数据");

            Message[] messages = queue.GetAllMessages();

            //Formatter 格式化程序
            var formatter = new System.Messaging.XmlMessageFormatter(new Type[] { typeof(MSMQModel) });//
            for (int i = 0; i < messages.Length; i++)
            {
                messages[i].Formatter = formatter;
                list.Add((MSMQModel)messages[i].Body);
            }

            return list;
        }

        static object obj = new object();

        static object GetMessageQueueReceive(string name)
        {
            List<MSMQModel> list = new List<MSMQModel>();
            MessageQueue queue = new MessageQueue(".\\private$\\" + name);

            Message[] messages = queue.GetAllMessages();

            var formatter = new System.Messaging.XmlMessageFormatter(new Type[] { typeof(MSMQModel) });//
            foreach (Message item in messages)
            {          
                    var temp = queue.Receive();
                    temp.Formatter = formatter;
                    list.Add((MSMQModel)temp.Body);
            }
            return list;
        }
    }

    public class MSMQModel
    {
        public string ID { get { return Guid.NewGuid().ToString(); } }

        public string Name { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
