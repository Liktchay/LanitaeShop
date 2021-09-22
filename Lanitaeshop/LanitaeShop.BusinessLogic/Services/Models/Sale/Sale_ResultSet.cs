using System;
using System.Collections.Generic;
using System.Text;

namespace LanitaeShop.BusinessLogic.Services.Models.Sale
{
    public class Sale_ResultSet
    {
        public int id { get; set; }
        public int productID { get; set; }
        public int saleTotalAmount { get; set; }
        public int personID { get; set; }
        public DateTime saleDateTime { get; set; }
    }
}
