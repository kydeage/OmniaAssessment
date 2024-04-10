using Microsoft.EntityFrameworkCore;
using OmniaDataAccess.Entities;

namespace OmniaDataAccess
{
    public class OmniaDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }

        public OmniaDbContext(DbContextOptions<OmniaDbContext> options) : base(options)
        {
            GenerateDummyData();
        }

        /// <summary>
        /// This method is created just for demonstration purposes. 
        /// If the DbSets are empty they will be populated with some dummy data. 
        /// </summary>
        private void GenerateDummyData()
        {
            if (!Products.Any())
            {
                Products.AddRange(
                    new Product
                    {
                        Id = 1,
                        Name = "Dummy Product 1"
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Dummy Product 2"
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Dummy Product 3"
                    });
            }

            if (!ProductDetails.Any())
            {
                ProductDetails.AddRange(
                    new ProductDetails
                    {
                        Id = 1,
                        RetailerId = 1,
                        ProductId = 1,
                        Category = "Category 1",
                        Description = "A product",
                        Price = 20.5f
                    },
                    new ProductDetails
                    {
                        Id = 2,
                        RetailerId = 2,
                        ProductId = 1,
                        Category = "Category 1",
                        Description = "A product",
                        Price = 18.7f
                    },
                    new ProductDetails
                    {
                        Id = 3,
                        RetailerId = 1,
                        ProductId = 2,
                        Category = "Category 2",
                        Description = "A product",
                        Price = 1.2f,
                        DiscountPercentage = 17
                    });
            }

            SaveChanges();
        }
    }
}