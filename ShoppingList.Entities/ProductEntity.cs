using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Infastructure
{
    public class ProductEntity
    {
        [Key]
        public required string Name { get; set; }
    }
}
