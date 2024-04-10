namespace OmniaDataModels.Products
{
    public class ProductDetailsDto
    {
        public required int Id { get; set; }
        public required int ProductId { get; set; }
        public required int RetailerId { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public float Price { get; set; }
        public float DiscountPercentage { get; set; }
        public int Stock { get; set; }
    }
}