using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace DDDCompany.Application
{
    
    public class Bootstrapper  //Bootstrapper : 启动加载器；引导程序
    {
        private readonly string WCF_BaseUrl = ConfigurationManager.AppSettings["WCF_BaseUrl"];

        /// <summary>
        /// 开启所有的WCF服务
        /// </summary>
        public void Start_Services()
        {
            //1.读取此程序集里面的有服务契约的接口和实现类

            var assembly = Assembly.Load(typeof(Bootstrapper).Namespace);

            //获取程序集中所有的类型
            var types = assembly.GetTypes();

            List<Type> Interface_List = new List<Type>();
            List<Type> Classes_List = new List<Type>();

            foreach (var type in types)
            {
                var custom_attributes = type.CustomAttributes; //获取所有特性
                if (custom_attributes.Count() <= 0)
                {
                    continue;
                }

                //获取标记为 [ServiceInterface] 特性的接口
                var InterFace_Attributes = custom_attributes.FirstOrDefault(c => c.AttributeType.Equals(typeof(ServiceInterfaceAttribute)));
                if (InterFace_Attributes != null)
                {
                    Interface_List.Add(type);
                    continue;
                }

                //获取标记为 [ServiceClass] 特性的接口
                var ServiceClass_Attributes = custom_attributes.FirstOrDefault(c => c.AttributeType.Equals(typeof(ServiceClassAttribute)));
                if (ServiceClass_Attributes != null)
                {
                    Classes_List.Add(type);
                }
            }


            //开启所有服务 Start WCF Service
            foreach (var I_face in Interface_List)
            {
                //通过反射找到接口的实现类，找到配对然后启动服务

                var ClassTemps = Classes_List.Where(c => c.GetInterface(I_face.Name) != null).ToList();

                if (ClassTemps.Count <= 0)
                {
                    continue;
                }
                if (ClassTemps[0].GetInterface(I_face.Name).Equals(I_face))
                {
                    var O_Task = Task.Factory.StartNew(() =>
                    {
                        Open_Service(WCF_BaseUrl + "/" + I_face.Name, I_face, ClassTemps[0]);
                    });
                }
            }

        }

        /// <summary>
        ///通过服务接口类型和实现类型启动WCF服务
        /// </summary>
        /// <param name="strServiceUrl">WCF_URL</param>
        /// <param name="typeInterface">接口</param>
        /// <param name="typeclass">接口实现类</param>
        private void Open_Service(string strServiceUrl, Type typeInterface, Type typeclass)
        {
            Uri HttpAddress = new Uri(strServiceUrl);

            using (ServiceHost host = new ServiceHost(typeclass))
            {
                //-----------------------添加服务节点-----------------------
                host.AddServiceEndpoint(typeInterface, new WSHttpBinding(), HttpAddress);
                if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                {
                    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;
                    behavior.HttpGetUrl = HttpAddress;
                    host.Description.Behaviors.Add(behavior);    
                }
                //HTTP 无法注册 URL http://+:9409/MyWCF.Server/IFactoryLayoutWCFService/。进程不具有此命名空间的访问权限  Win7 VS以管理员身份打开   ( Win7 以管理员身份打开VS即可 )
                host.Opened += delegate 
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("服务启动成功。服务地址：" + strServiceUrl);
                };
                host.Open();
                while (true)
                {
                    Console.ReadLine();
                }
            }
        }
    }
}
