using System;
using System.Collections.Generic;
using System.Text;

namespace LanitaeShop.BusinessLogic.Services.Models.Product
{
    public class Product_ResultSet
    {
        public int id { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public int? productPrice { get; set; }
        public int? productStock { get; set; }
        public bool? productEnable { get; set; }
    }
}
