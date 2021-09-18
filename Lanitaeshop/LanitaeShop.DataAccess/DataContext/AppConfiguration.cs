using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace LanitaeShop.DataAccess.DataContext
{
    public class AppConfiguration
    {
        public AppConfiguration()
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            string connectionStringPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            configurationBuilder.AddJsonFile(connectionStringPath, false);

            IConfigurationRoot root = configurationBuilder.Build();

            IConfigurationSection appSettings = root.GetSection("ConnectionStrings:DefaultConnection");

            SqlConnectionString = appSettings.Value;
        }

        public String SqlConnectionString { get; set; }

    }
}
