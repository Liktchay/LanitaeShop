using System;
using System.Collections.Generic;
using System.Text;

namespace LanitaeShop.BusinessLogic.Services.Models
{
    public class ResultSet<T> : StandarResultSet where T : class
    {
        public T result_set { get; set; }
    }
}
