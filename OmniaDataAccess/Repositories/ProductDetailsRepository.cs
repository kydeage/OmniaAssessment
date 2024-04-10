using Microsoft.EntityFrameworkCore;
using OmniaDataAccess.Entities;
using OmniaDataAccess.Repositories.Interfaces;

namespace OmniaDataAccess.Repositories
{
    public class ProductDetailsRepository : IProductDetailsRepository
    {
        private readonly OmniaDbContext _dataContext;

        public ProductDetailsRepository(OmniaDbContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        /// <summary>
        /// Queries the dataContext for all ProductDetails matching a specified ProductId
        /// </summary>
        /// <param name="productId">The Id of the desired product</param>
        /// <returns>Returns a List of ProductDetails objects</returns>
        public async Task<IEnumerable<ProductDetails>> GetProductDetails(int productId)
        {
            var productDetails = await _dataContext.ProductDetails.Where(p => p.ProductId == productId).ToListAsync();

            return productDetails;
        }

        /// <summary>
        /// Gets all the Prices for a specified ProductId 
        /// </summary>
        /// <param name="productId">The id of the desired Product</param>
        /// <returns>Returns a List of floats for all the prices associated with the provided ProductId</returns>
        public async Task<IEnumerable<float>> GetAllProductPrices(int productId)
        {
            var prices = await _dataContext.ProductDetails.Where(p => p.ProductId == productId).Select(p => p.Price).ToListAsync();

            return prices;
        }

        /// <summary>
        /// Updates the price of the specified ProductDetails if there is a matching dataContext entry with the same ProductId
        /// and RetailerId.
        /// </summary>
        /// <param name="productDetails">The object representing the existing ProductDetails</param>
        /// <param name="newPrice">A float specifying the desired new price.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Throws an error if the existing ProductDetails can't be found</exception>
        public async Task UpdateProductPrice(ProductDetails productDetails, float newPrice)
        {
            var existingDetails = await _dataContext.ProductDetails.FirstAsync(p => p.ProductId == productDetails.ProductId
                && p.RetailerId == productDetails.RetailerId);

            if (existingDetails != null)
            {
                existingDetails.Price = newPrice;
                _dataContext.ProductDetails.Update(existingDetails);
                _dataContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Method {nameof(UpdateProductPrice)} failed.");
            }
        }
    }
}