using Microsoft.AspNetCore.Mvc.Testing;
using OmniaDataAccess.Entities;
using OmniaDataModels.Products;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using Xunit;

namespace OmniaTests
{
    [TestClass]
    public class ProductDetailsControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory = new WebApplicationFactory<Program>();

        [TestMethod]
        public async Task GET_fetch_all_details_first_product()
        {
            using var client = _factory.CreateClient();

            var response = await client.GetAsync("/productdetails/1");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GET_fetch_all_prices_first_product()
        {
            using var client = _factory.CreateClient();

            var response = await client.GetAsync("/productdetails/1/prices");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        [TestMethod]
        public async Task POST_set_price_first_product()
        {
            using var client = _factory.CreateClient();
            var productDetails = new ProductDetailsPriceDto
            {
                ProductDetailsDto = new ProductDetailsDto
                {
                    Id = 2,
                    RetailerId = 2,
                    ProductId = 1,
                    Category = "Category 1",
                    Description = "A product",
                    Price = 18.7f
                },
                NewPrice = 12.0f
            };

            var requestContent = JsonContent.Create(productDetails, typeof(ProductDetailsPriceDto));

            var response = await client.PostAsync("/productdetails/1/prices", requestContent);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}