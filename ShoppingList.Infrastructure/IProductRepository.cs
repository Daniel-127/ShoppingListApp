using Microsoft.AspNetCore.Http.HttpResults;
using ShoppingList.Core;

namespace ShoppingList.Infrastructure
{
    public interface IProductRepository
    {
        Task<Results<Ok, Conflict<Product>>> CreateAsync(Product product);
        Task<Results<NoContent, NotFound<string>>> DeleteAsync(string name);
        Task<IReadOnlyCollection<Product>> ReadAsync(); 
    }
}
