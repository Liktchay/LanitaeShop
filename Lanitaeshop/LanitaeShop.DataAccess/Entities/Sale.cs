using System;
using System.Collections.Generic;
using System.Text;

namespace LanitaeShop.DataAccess.Entities
{
    public class Sale
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int SaleTotalAmount { get; set; }
        public int PersonID { get; set; }
        public Person Person { get; set; }
        public DateTime SaleDate { get; set; }       
    }
}
