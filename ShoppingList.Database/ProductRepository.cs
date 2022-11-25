using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Core;

namespace ShoppingList.Infastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShoppingListContext context;

        public ProductRepository(ShoppingListContext context) 
        {
            this.context = context;
        }

        public async Task<Results<Ok, Conflict<Product>>> CreateAsync(Product product)
        {
            var entity = await context.Products.FindAsync(product.Name);
            if (entity is null)
            {
                entity = product.Convert();
                context.Products.Add(entity);
                await context.SaveChangesAsync();
                return TypedResults.Ok();
            }
            else
            {
                return TypedResults.Conflict(entity.Convert());
            }
        }

        public async Task<Results<NoContent, NotFound<string>>> DeleteAsync(string name)
        {
            var product = await context.Products.FindAsync(name);
            if (product is null)
            {
                return TypedResults.NotFound(name);
            }
            else
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
                return TypedResults.NoContent();
            }
        }

        public async Task<IReadOnlyCollection<Product>> ReadAsync()
        {
            var products = from p in context.Products
                           orderby p.Name
                           select p.Convert();

            return await products.ToArrayAsync();
        }
    }
}
