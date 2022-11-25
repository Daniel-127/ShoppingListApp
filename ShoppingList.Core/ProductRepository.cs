using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Core
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShoppingListContext context;

        public ProductRepository(ShoppingListContext context) 
        {
            this.context = context;
        }

        public void Add(ProductDTO product)
        {
            var p = new Product { Name= product.Name };
            context.Products.Add(p);
            context.SaveChanges();
        }

        public bool Delete(string name)
        {
            name = name.ToLower();
            var product = context.Products.FirstOrDefault(p => p.Name.ToLower() == name);
            bool exists = product != null;
            if (exists)
            {
                context.Products.Remove(product!);
            }
            context.SaveChanges();
            return exists;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            return context.Products.Select(p => new ProductDTO(p.Name));
        }
    }
}
