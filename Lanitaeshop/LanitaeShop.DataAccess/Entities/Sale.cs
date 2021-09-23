using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace LanitaeShop.DataAccess.Entities
{
    public class Sale
    {
        public int ID { get; set; }
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
