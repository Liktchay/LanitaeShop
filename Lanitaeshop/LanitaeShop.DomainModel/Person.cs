using System;
using System.Collections.Generic;
using System.Text;

namespace LanitaeShop.DomainModel
{
    public class Person : BaseEntity, IBaseEntity
    {
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public string PersonAddress { get; set; }
        public List<Sale> Sale { get; set; }
    }
}
