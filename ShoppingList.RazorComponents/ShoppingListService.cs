using ShoppingList.Core;

namespace ShoppingList.RazorComponents
{
    public class ShoppingListService : IShoppingListService
    {
        public Task<bool> Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public (IEnumerable<Product>, Task<(bool, IEnumerable<Product>)>) GetProducts()
        {
            var current = new List<Product>
            {
                new Product("Apple"),
                new Product("Banana"),
                new Product("Orange"),
                new Product("Apple"),
                new Product("Banana"),
                new Product("Orange"),
                new Product("Apple"),
                new Product("Banana"),
                new Product("Orange"),
                new Product("Apple"),
                new Product("Banana"),
                new Product("Orange"),
                new Product("Apple"),
                new Product("Banana"),
                new Product("Orange")
            };
            async Task<(bool, IEnumerable<Product>)> delayedProducts()
            {
                await Task.Delay(5000);
                var newData = new List<Product>(current)
                {
                    new Product("Carrot")
                };
                return (true, newData);
            }
            return (current, delayedProducts());
            throw new NotImplementedException();
        }
    }
}
