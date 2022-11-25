using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Core
{
    public interface IProductRepository
    {
        void Add(Product product);
        bool Delete(string name);
        IEnumerable<Product> GetAll(); 
    }
}
