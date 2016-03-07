using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace BlogSytemManager.IService.Self
{
    /// <summary>
    /// EF 禁止用服务代理类，反序列化成 :BaseObject
    /// </summary>
    public class ApplyProxyDataContractResolverAttribute : Attribute, IOperationBehavior
    {
        public void AddBindingParameters(OperationDescription description, BindingParameterCollection parameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription description, ClientOperation proxy)
        {
            DataContractSerializerOperationBehavior
                       dataContractSerializerOperationBehavior =
                          description.Behaviors.Find<DataContractSerializerOperationBehavior>();
            dataContractSerializerOperationBehavior.DataContractResolver = new ProxyDataContractResolver();
        }

        public void ApplyDispatchBehavior(OperationDescription description, DispatchOperation dispatch)
        {
            DataContractSerializerOperationBehavior
                       dataContractSerializerOperationBehavior = description.Behaviors.Find<DataContractSerializerOperationBehavior>();
            dataContractSerializerOperationBehavior.DataContractResolver = new ProxyDataContractResolver();
        }
        public void Validate(OperationDescription description)
        {
        }
    }
}
