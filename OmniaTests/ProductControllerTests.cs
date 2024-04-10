using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;

namespace OmniaTests
{
    [TestClass]
    public class ProductControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory = new WebApplicationFactory<Program>();

        [TestMethod]
        public async Task GET_fetch_all_products()
        {
            using var client = _factory.CreateClient();

            var response = await client.GetAsync("/product");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

    }
}