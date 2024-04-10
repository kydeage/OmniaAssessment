using OmniaDataAccess.Entities;

namespace OmniaDataAccess.Repositories.Interfaces
{
    public interface IProductDetailsRepository
    {
        public Task<IEnumerable<ProductDetails>> GetProductDetails(int productId);
        public Task<IEnumerable<float>> GetAllProductPrices(int productId);
        public Task UpdateProductPrice(ProductDetails productDetails, float newPrice);
    }
}