using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Database
{
    public class ShoppingListContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public ShoppingListContext(DbContextOptions<ShoppingListContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
