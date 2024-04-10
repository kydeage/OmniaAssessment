namespace OmniaDataModels.Products
{
    public class ProductDetailsPriceDto
    {
        public required ProductDetailsDto ProductDetailsDto { get; set; }
        public float NewPrice { get; set; }
    }
}