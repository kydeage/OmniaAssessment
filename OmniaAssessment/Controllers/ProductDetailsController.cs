using Microsoft.AspNetCore.Mvc;
using OmniaAPI.Mapping;
using OmniaDataAccess.Repositories.Interfaces;
using OmniaDataModels.Products;

namespace OmniaAssessment.Controllers
{
    [Route("productdetails")]
    [ApiController]
    public class ProductDetailsController
    {
        private readonly IProductDetailsRepository _productDetailsRepository;

        public ProductDetailsController(IProductDetailsRepository productDetailsRepository)
        {
            _productDetailsRepository = productDetailsRepository ?? throw new ArgumentNullException(nameof(productDetailsRepository));
        }

        /// <summary>
        /// This method returns all ProductDetailsDto objects associated with a specified ProductId
        /// </summary>
        /// <param name="productId">The Id of the product as in int for which you wish to see the details</param>
        /// <returns>Returns a List of ProductDetailsDto objects</returns>
        /// <exception cref="Exception">Only throws an exception if the API call somehow returns null</exception>
        [HttpGet("{productId}")]
        public async Task<IEnumerable<ProductDetailsDto>> GetProductDetails(int productId)
        {
            var productDetails = await _productDetailsRepository.GetProductDetails(productId);

            if (productDetails == null)
            {
                throw new Exception($"Method {nameof(GetProductDetails)} failed.");
            }

            var productDetailsDtos = new List<ProductDetailsDto>();
            foreach (var productDetail in productDetails)
            {
                productDetailsDtos.Add(ProductDetailsMapper.MapToDto(productDetail));
            }

            return productDetailsDtos;
        }

        /// <summary>
        /// Fetches all the prices associated with a specified ProductId
        /// </summary>
        /// <param name="productId">The Id of the product as in int for which you wish to see the prices</param>
        /// <returns>Returns a list of floats for all the prices of the specified product</returns>
        /// <exception cref="Exception">Only throws an exception if the API call somehow returns null</exception>
        [HttpGet("{productId}/prices")]
        public async Task<IEnumerable<float>> GetAllProductPrices(int productId)
        {
            var productPrices = await _productDetailsRepository.GetAllProductPrices(productId);

            if (productPrices == null)
            {
                throw new Exception($"Method {nameof(GetAllProductPrices)} failed.");
            }

            return productPrices;
        }

        /// <summary>
        /// Looks for the existing ProductDetails with a matching ProductId and RetailerId, then updates the price to the newly specified one.
        /// </summary>
        /// <param name="productDetailsPriceDto">An object containing the ProductDetailsDto and a float for the new price</param>
        /// <returns>Only throws an exception if the ProductDetailsPriceDto parameter is null</returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("{productId}/prices")]
        public Task UpdateProductPrice(ProductDetailsPriceDto productDetailsPriceDto)
        {
            if (productDetailsPriceDto == null)
            {
                throw new Exception($"Method {nameof(UpdateProductPrice)} failed.");
            }

            var productDetails = ProductDetailsMapper.MapToEntity(productDetailsPriceDto.ProductDetailsDto);

            return _productDetailsRepository.UpdateProductPrice(productDetails, productDetailsPriceDto.NewPrice);
        }
    }
}