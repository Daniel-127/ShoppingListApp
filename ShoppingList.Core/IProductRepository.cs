using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Core
{
    public interface IProductRepository
    {
        void Add(ProductDTO product);
        bool Delete(string name);
        IEnumerable<ProductDTO> GetAll(); 
    }
}
