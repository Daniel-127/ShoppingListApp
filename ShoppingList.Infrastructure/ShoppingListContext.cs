using Microsoft.EntityFrameworkCore;

namespace ShoppingList.Infrastructure
{
	public class ShoppingListContext : DbContext
    {
        public DbSet<ProductEntity> Products => Set<ProductEntity>();
        public ShoppingListContext(DbContextOptions<ShoppingListContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>().HasKey(e => e.KeyName);
        }
    }
}
