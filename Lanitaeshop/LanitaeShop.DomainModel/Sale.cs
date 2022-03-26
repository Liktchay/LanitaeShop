using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LanitaeShop.DomainModel
{
    public class Sale : BaseEntity, IBaseEntity
    {
        [Column("Product_ID")]
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int SaleTotalAmount { get; set; }
        [Column("Person_ID")]
        public int PersonID { get; set; }
        public Person Person { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
