using System;
using System.Collections.Generic;
using System.Text;

namespace LanitaeShop.BusinessLogic.Services.Models
{
    public class ResultSet_List<T> : StandarResultSet where T : class
    {
        public List<T> result_set { get; set; }
    }
}
