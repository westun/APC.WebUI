using APC.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace APC.DAL.DataAccess
{
    public class APCContext : DbContext
    {
        public APCContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();
            //var connectionString = configuration.GetConnectionString("DbCoreConnectionString");
            //optionsBuilder.UseSqlServer(connectionString);

            //TODO: store/get connection string from more secure location
            //optionsBuilder.UseSqlServer(
            //    @"server=localhost;Initial Catalog=APC;Integrated Security=true;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<AreasOfApplication> AreasOfApplication { get; set; }

        public DbSet<ProductAttribute> ProductAttribute { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this is old entity framework
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
