using ShoppingList.Core;

namespace ShoppingList.App.Data
{
    internal interface IShoppingListService
    {
        Task<bool> Add(Product product);

        void Delete(Product product);

        (IEnumerable<Product>, Task<(bool, IEnumerable<Product>)>) GetProducts();
    }
}
