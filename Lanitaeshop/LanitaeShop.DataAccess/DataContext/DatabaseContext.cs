using System;
using Microsoft.EntityFrameworkCore;
using LanitaeShop.DataAccess.Entities;
using LanitaeShop.DataAccess.Mapping;

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

        /// <summary>
        /// Applies all mapping and configurations defined within the assembly.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new SaleMap());
            //modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        

    }
}
