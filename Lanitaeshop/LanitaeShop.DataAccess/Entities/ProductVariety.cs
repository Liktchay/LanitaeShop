using System.ComponentModel.DataAnnotations.Schema;

namespace LanitaeShop.DataAccess.Entities
{
    public class ProductVariety
    {
        public int ID { get; set; }

        [Column("Product_ID")]
        public int ProductID { get; set; }

        public Product Product { get; set; }

        public string ProductDescription { get; set; }

        public string Color { get; set; }

        public int Stock { get; set; }
    }
}
