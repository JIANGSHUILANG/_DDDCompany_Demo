using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolgSytemManager.Domain.Base
{
    #region IAggregateRoot

    public interface IEntity { }

    public interface IAggregateRoot : IEntity { }

    public abstract class AggregateRoot : IAggregateRoot
    {
        public int ID { get; set; }
    }

    #endregion
}
