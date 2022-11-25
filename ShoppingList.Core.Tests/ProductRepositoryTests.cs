using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.Sqlite;

namespace ShoppingList.Infastructure.Tests
{
    public class ProductRepositoryTests : IDisposable
    {
        ProductRepository repository;
        ShoppingListContext context;

        public ProductRepositoryTests()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            var builder = new DbContextOptionsBuilder<ShoppingListContext>();
            builder.UseSqlite(connection);

            context = new ShoppingListContext(builder.Options);
            context.Database.EnsureCreated();

            repository = new ProductRepository(context);

            var p1 = new ProductEntity { Name = "Orange" };
            var p2 = new ProductEntity { Name = "Banana" };

            context.Products.AddRange(p1, p2);
            context.SaveChanges();
        }


        [Fact]
        public async Task TestAdd()
        {
            var product = new Product("Apple");

            var result = await repository.CreateAsync(product);

            result.Result.Should().BeOfType<Ok>();
            context.Products.Should().Contain(p => p.Name == product.Name);
        }

        [Fact]
        public async Task TestDelete()
        {
            var result = await repository.DeleteAsync("Orange");

            result.Result.Should().BeOfType<NoContent>();
            context.Products.Should().NotContain(p => p.Name == "Orange");
        }

        [Fact]
        public async Task TestGetAll()
        {
            var products = await repository.ReadAsync();

            products.Should().BeEquivalentTo(new List<Product>
            {
                new Product("Orange"),
                new Product("Banana"),
            });
        }

        public void Dispose() => context.Dispose();
    }
}
