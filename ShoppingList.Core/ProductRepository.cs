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
            throw new NotImplementedException();
        }

        public bool Delete(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
