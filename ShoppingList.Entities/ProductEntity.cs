using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Infastructure
{
    public class ProductEntity
    {
        public required string KeyName { get; set; }
        public required string Name { get; set; }
    }
}
