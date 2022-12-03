using ShoppingList.Core;

namespace ShoppingList.App.Data
{
    internal class ShoppingListService : IShoppingListService
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
            throw new NotImplementedException();
        }
    }
}
