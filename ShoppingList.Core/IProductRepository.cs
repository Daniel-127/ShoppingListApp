using Microsoft.AspNetCore.Http.HttpResults;

namespace ShoppingList.Core
{
    public interface IProductRepository
    {
        Task<Results<Ok, Conflict<Product>>> CreateAsync(Product product);
        Task<Results<NoContent, NotFound<string>>> DeleteAsync(string name);
        Task<IReadOnlyCollection<Product>> ReadAsync(); 
    }
}
