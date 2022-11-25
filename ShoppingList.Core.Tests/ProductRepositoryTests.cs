using ShoppingList.Database;
using Microsoft.Data.Sqlite;

namespace ShoppingList.Core.Tests
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

            var p1 = new Product { Name = "Orange", Price = 3 };
            var p2 = new Product { Name = "Banana", Price = 4 };

            context.Products.AddRange(p1, p2);
            context.SaveChanges();
        }


        [Fact]
        public void TestAdd()
        {
            var product = new ProductDTO("Apple", 2);
            repository.Add(product);

            context.Products.Should().Contain(p => p.Name == product.Name & p.Price == product.price);
        }

        [Fact]
        public void TestDelete()
        {
            bool deleted = repository.Delete("Orange");

            deleted.Should().BeTrue();
            context.Products.Should().NotContain(p => p.Name == "Orange");
        }

        [Fact]
        public void TestGetAll()
        {
            var products = repository.GetAll();

            products.Should().BeEquivalentTo(new List<ProductDTO>
            {
                new ProductDTO("Orange", 3),
                new ProductDTO("Banana", 4),
            });
        }

        public void Dispose() => context.Dispose();
    }
}
