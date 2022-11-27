using ShoppingList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Infastructure
{
    public static class EntityConversions
    {
        public static Product Convert(this ProductEntity entity) => new Product(entity.Name);
        public static ProductEntity Convert(this Product entity) => new ProductEntity { KeyName = entity.Name.ToLower(), Name = entity.Name };
    }
}
