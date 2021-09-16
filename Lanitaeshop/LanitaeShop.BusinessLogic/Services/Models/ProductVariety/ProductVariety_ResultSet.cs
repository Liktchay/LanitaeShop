using System;
using System.Collections.Generic;
using System.Text;

namespace LanitaeShop.BusinessLogic.Services.Models.ProductVariety
{
    public class ProductVariety_ResultSet
    {
        public int id { get; set; }

        public int productID { get; set; }

        public string productDescription { get; set; }

        public string color { get; set; }

        public int stock { get; set; }
    }
}
