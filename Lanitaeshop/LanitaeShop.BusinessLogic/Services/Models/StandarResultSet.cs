using System;
using System.Collections.Generic;
using System.Text;

namespace LanitaeShop.BusinessLogic.Services.Models
{
    public abstract class StandarResultSet
    {

        public StandarResultSet()
        {
            success = false;
            userMessage = string.Empty;
            internalMessage = string.Empty;
            exception = null;
        }

        public bool success { get; set; }

        public string userMessage { get; set; }

        internal string internalMessage { get; set; }

        internal Exception exception { get; set; }



    }
}
