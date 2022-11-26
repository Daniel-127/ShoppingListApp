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
            modelBuilder.Entity<ProductEntity>().HasKey(e => e.Name);
            modelBuilder.Entity<ProductEntity>(e =>
            {
                e.Property(e => e.Name).Metadata.SetValueComparer(new ValueComparer<string>(
                    (n1, n2) => test(n1, n2),
                    n => n.ToUpper().GetHashCode(),
                    n => n
                ));
            });
        }

        private bool test(string? s1, string? s2)
        {
            bool value = string.Equals(s1, s2, StringComparison.OrdinalIgnoreCase);
            Console.WriteLine($"{s1} == {s2} is {value}");
            return value;
        }
    }
}
