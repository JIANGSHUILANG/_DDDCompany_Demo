using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDCompany.Domain.BaseModel
{
    /// <summary>
    /// 聚合跟接口，用作泛型约束，约束领域实体为聚合跟，
    /// 表示实现了该接口的为聚合根实例，由于聚合根也是领域实体的一种，所以也要实现IEntity接口
    /// </summary>
   public interface IAggregateRoot:IEntity
    {
    }
}
