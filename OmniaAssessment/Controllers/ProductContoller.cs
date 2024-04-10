using Microsoft.AspNetCore.Mvc;
using OmniaAPI.Mapping;
using OmniaDataAccess.Repositories.Interfaces;
using OmniaDataModels.Products;

namespace OmniaAPI.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductContoller
    {
        private readonly IProductRepository _productRepository;

        public ProductContoller(IProductRepository productRepository) 
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        /// <summary>
        /// Gets all the products via the ProductRepository
        /// </summary>
        /// <returns>Returns a List of ProductDtos</returns>
        /// <exception cref="Exception"></exception>
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var products = await _productRepository.GetProducts();

            if (products == null)
            {
                throw new Exception($"Method {nameof(GetProducts)} failed.");
            }

            var productDtos = products.Select(ProductMapper.MapToDto).ToList();
            return productDtos;
        }
    }
}