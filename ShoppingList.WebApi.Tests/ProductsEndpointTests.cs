using Microsoft.AspNetCore.Http.HttpResults;
using System.Net.Http.Json;
using System.Net;

namespace ShoppingList.WebApi.Tests
{
    [TestCaseOrderer("ShoppingList.WebApi.Tests.PriorityOrderer", "ShoppingList.WebApi.Tests")]
    public class ProductsEndpointTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient client;
        public ProductsEndpointTests(CustomWebApplicationFactory factory) 
        {
            client = factory.CreateClient();
        }

        [Fact, TestPriority(0)]
        public async Task Get()
        {
            var products = await client.GetFromJsonAsync<IEnumerable<Product>>("products");

            products.Should().BeEquivalentTo(new List<Product>
            {
                new Product("Apple"),
                new Product("Orange")
            });
        }

        [Fact, TestPriority(1)]
        public async Task Post_Ok()
        {
            var response = await client.PostAsJsonAsync("products", new Product("Banana"));

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact, TestPriority(2)]
        public async Task Delete_NoContent()
        {
            var response = await client.DeleteAsync("products/Apple");

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact, TestPriority(3)]
        public async Task TestDelete_NotFound()
        {
            var response = await client.DeleteAsync("products/Carrot");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            var name = await response.Content.ReadFromJsonAsync<string>();
            name.Should().Be("Carrot");
        }

        [Fact, TestPriority(4)]
        public async Task TestPost_Conflict()
        {
            var response = await client.PostAsJsonAsync("products", new Product("Orange"));

            response.StatusCode.Should().Be(HttpStatusCode.Conflict);

            var product = await response.Content.ReadFromJsonAsync<Product>();
            product!.Name.Should().Be("Orange");
        }

        [Fact, TestPriority(5)]
        public async Task TestGet_Modified()
        {
            var products = await client.GetFromJsonAsync<IEnumerable<Product>>("products");

            products.Should().BeEquivalentTo(new List<Product>
            {
                new Product("Banana"),
                new Product("Orange")
            });
        }

        [Fact, TestPriority(6)]
        public async Task TestDelete_CaseInsensetive_NoContent()
        {
            var response = await client.DeleteAsync("products/banana");

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact, TestPriority(7)]
        public async Task TestPost_CaseInsensitive_Conflict()
        {
            var response = await client.PostAsJsonAsync("products", new Product("orange"));

            response.StatusCode.Should().Be(HttpStatusCode.Conflict);
        }
    }
}
