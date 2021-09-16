using System.Collections.Generic;

namespace LanitaeShop.DataAccess.Entities
{
    public class Product
    {
        public int ID { get; set; }

        public string Garment { get; set; }

        public float Price { get; set; }

        public ICollection<ProductVariety> ProductVariety { get; set; }
    }
}
