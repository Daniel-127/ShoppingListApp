using ShoppingList.Core;

namespace ShoppingList.RazorComponents
{
    public interface IShoppingListService
    {
        Task<bool> Add(Product product);

        void Delete(Product product);

        (IEnumerable<Product>, Task<(bool, IEnumerable<Product>)>) GetProducts();
    }
}
