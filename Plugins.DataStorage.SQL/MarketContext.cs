using CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace Plugins.DataStorage.SQL
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public  DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Beverage", Description = "Beverage" },
                new Category { CategoryId = 2, Name = "Bakery", Description = "Bakery" },
                new Category { CategoryId = 3, Name = "Meat", Description = "Meat" }

                );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, CategoryId = 1, Name = "Iced-Tea", Quantity = 120, Price = 120.00 },
                new Product { ProductId = 2, CategoryId = 1, Name = "Canada Dry", Quantity = 100, Price = 100.00 },
                new Product { ProductId = 3, CategoryId = 2, Name = "Brown Bread", Quantity = 60, Price = 300.00 },
                new Product { ProductId = 3, CategoryId = 2, Name = "Bun", Quantity = 150, Price = 350.00 }

                );
        }
    }
}