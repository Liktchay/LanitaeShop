using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace LanitaeShop.DataAccess.Entities
{
    [Keyless]
    public class AllVarietiesResult
    {
        public string Garment { get; set; }

        public decimal Price { get; set; }

        [Column("Product_Description")]
        public string ProductDescription { get; set; }

        public string Color { get; set; }

        public int Stock { get; set; }
    }
}
