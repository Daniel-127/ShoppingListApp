using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Database
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required double Price { get; set; }
    }
}
