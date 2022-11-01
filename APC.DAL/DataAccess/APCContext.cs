using APC.DAL.Models;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<ProductAttributeValue> ProductAttributeValue { get; set; }
        public DbSet<SimilarProducts> SimilarProducts { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<CompatibleProducts> CompatibleProducts { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartProduct>(eb =>
            {
                eb.HasKey(c => new { c.CartId, c.ProductId });
                eb.ToTable("CartProduct");
                eb.Property(p => p.ProductQuantity)
                    .HasColumnName("ProductQuantity");

                //EF automatically configured these relationships correctly, adding for example
                eb.HasOne(cp => cp.Cart)
                    .WithMany(cp => cp.CartProducts);

                eb.HasOne(cp => cp.Product)
                    .WithMany(cp => cp.CartProducts);
            });

            modelBuilder.Entity<Cart>(eb => 
            {
                eb.ToTable("Cart");

                eb.HasOne(c => c.Account)
                    .WithMany(a => a.Carts);

                eb.HasMany(c => c.CartProducts)
                    .WithOne(cp => cp.Cart);
            });

            modelBuilder.Entity<Product>(eb => 
            {
                eb.HasMany(p => p.CartProducts)
                    .WithOne(cp => cp.Product);
            });

        }
    }
}
