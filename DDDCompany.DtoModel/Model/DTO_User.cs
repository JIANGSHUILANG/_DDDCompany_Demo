using DDDCompany.DtoModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DDDCompany.DtoModel.Model
{
    [DataContract]
    public class DTO_User : DTO_BaseModel
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Cell { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public Nullable<bool> Status { get; set; }

        [DataMember]
        public Nullable<System.DateTime> CreateTime { get; set; }

        [DataMember]
        public int Role_ID { get; set; }

         [DataMember]
        public string Role_Name{ get; set; }

         [DataMember]
         public Nullable<int> Role_Status { get; set; }
    }
}
