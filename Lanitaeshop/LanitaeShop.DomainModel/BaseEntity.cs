using System;
using System.Collections.Generic;
using System.Text;

namespace LanitaeShop.DomainModel
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int ID { get ; set ; }
    }


}
