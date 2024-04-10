using OmniaDataAccess.Entities;
using OmniaDataModels.Products;

namespace OmniaAPI.Mapping
{
    public static class ProductDetailsMapper
    {
        public static ProductDetailsDto MapToDto(ProductDetails product)
        {
            return new ProductDetailsDto()
            {
                Id = product.Id,
                Description = product.Description,
                RetailerId = product.RetailerId,
                Category = product.Category,
                DiscountPercentage = product.DiscountPercentage,
                Price = product.Price,
                ProductId = product.ProductId,
                Stock = product.Stock
            };
        }

        public static ProductDetails MapToEntity(ProductDetailsDto productDto)
        {
            return new ProductDetails()
            {
                Id = productDto.Id,
                Description = productDto.Description,
                RetailerId = productDto.RetailerId,
                Category = productDto.Category,
                DiscountPercentage = productDto.DiscountPercentage,
                Price = productDto.Price,
                ProductId = productDto.ProductId,
                Stock = productDto.Stock
            };
        }
    }
}