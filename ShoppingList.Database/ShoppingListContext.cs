using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ShoppingList.Infastructure
{
    public class ShoppingListContext : DbContext
    {
        public DbSet<ProductEntity> Products => Set<ProductEntity>();
        public ShoppingListContext(DbContextOptions<ShoppingListContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>(e =>
            {
                e.Property(e => e.Name).Metadata.SetValueComparer(new ValueComparer<string>(
                    (n1, n2) => string.Equals(n1, n2, StringComparison.OrdinalIgnoreCase),
                    n => n.ToUpper().GetHashCode(),
                    n => n
                ));
            });
        }
    }
}
