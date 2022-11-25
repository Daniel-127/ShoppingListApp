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

        public void Add(Product product)
        {
            var p = new ProductEntity { Name = product.Name };
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

        public IEnumerable<Product> GetAll()
        {
            return context.Products.Select(p => new Product(p.Name));
        }
    }
}
