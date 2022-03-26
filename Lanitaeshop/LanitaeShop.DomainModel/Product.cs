using System;
using System.Collections.Generic;
using System.Text;

namespace LanitaeShop.DomainModel
{
    public class Product : BaseEntity, IBaseEntity
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int? ProductPrice { get; set; }
        public int? ProductStock { get; set; }
        public bool? ProductEnable { get; set; }
        public List<Sale> Sale { get; set; }

    }
}
