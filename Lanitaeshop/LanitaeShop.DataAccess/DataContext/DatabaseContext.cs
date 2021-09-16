using System;
using Microsoft.EntityFrameworkCore;

namespace LanitaeShop.DataAccess.DataContext
{
    public class DatabaseContext : DbContext
    {

        public class OptionsBuild
        {

            public OptionsBuild()
            {

                Settings = new AppConfiguration();

                OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

                OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);

                DatabaseOptions = OptionsBuilder.Options;
            }

            private AppConfiguration Settings { get; set; }

            public DbContextOptionsBuilder<DatabaseContext> OptionsBuilder { get; set; }

            public DbContextOptions<DatabaseContext> DatabaseOptions { get; set; }

        }

        public static OptionsBuild Options = new OptionsBuild();

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    }
}
