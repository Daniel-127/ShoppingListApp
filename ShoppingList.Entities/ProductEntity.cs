using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Infastructure
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
