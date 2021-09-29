using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanitaeShop.WebAPI.Models.GetProductsResult
{
    public class GetProductResult
    {
        public int id { get; set; }
        public string product_name { get; set; }
        public string product_description { get; set; }
        public int product_price { get; set; }
        public int product_stock { get; set; }
        public bool product_enable { get; set; }
    }
}
