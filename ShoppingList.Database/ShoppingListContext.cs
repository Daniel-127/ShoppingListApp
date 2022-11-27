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
            modelBuilder.Entity<ProductEntity>().HasKey(e => e.KeyName);
            /*modelBuilder.Entity<ProductEntity>(e =>
            {
                e.Property(p => p.Name).Metadata.SetValueComparer(new ValueComparer<string>(
                    (s1, s2) => string.Equals(s1, s2, StringComparison.OrdinalIgnoreCase),
                    s => s.ToUpper().GetHashCode(),
                    s => s
                ));
            });*/
        }
    }
}
