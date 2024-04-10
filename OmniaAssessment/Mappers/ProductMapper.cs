using OmniaDataAccess.Entities;
using OmniaDataModels.Products;

namespace OmniaAPI.Mapping
{
    public static class ProductMapper
    {
        public static ProductDto MapToDto(Product product)
        {
            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name
            };
        }

        public static Product MapToEntity(ProductDto productDto)
        {
            return new Product()
            {
                Id = productDto.Id,
                Name = productDto.Name
            };
        }
    }
}