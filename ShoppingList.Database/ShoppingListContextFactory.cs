using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Database
{
    public class ShoppingListContextFactory
    {
        public static ShoppingListContext CreateInMemoryDbContext()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            var builder = new DbContextOptionsBuilder<ShoppingListContext>();
            builder.UseSqlite(connection);

            var context = new ShoppingListContext(builder.Options);
            context.Database.EnsureCreated();

            return context;
        }
    }
}
