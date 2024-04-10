using OmniaDataAccess.Entities;

namespace OmniaDataAccess.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducts();
    }
}