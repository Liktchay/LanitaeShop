using System.Collections.Generic;

namespace LanitaeShop.DataAccess.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public bool ProductEnable { get; set; }
        public List<Sale> Sale { get; set; }
      
    }
}
