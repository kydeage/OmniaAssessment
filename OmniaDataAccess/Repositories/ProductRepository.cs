using Microsoft.EntityFrameworkCore;
using OmniaDataAccess.Entities;
using OmniaDataAccess.Repositories.Interfaces;

namespace OmniaDataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OmniaDbContext _dataContext;

        public ProductRepository(OmniaDbContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        /// <summary>
        /// Returns a List of all Product objects
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _dataContext.Products.ToListAsync();

            return products;
        }
    }
}