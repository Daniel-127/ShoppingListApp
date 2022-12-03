using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ShoppingList.Infrastructure
{
    public class ShoppingListContextFactory : IDesignTimeDbContextFactory<ShoppingListContext>
    {
        public readonly static Lazy<SqliteConnection> SqliteConn = new Lazy<SqliteConnection>(() => 
        {
            var conn = new SqliteConnection("Filename=:memory:");
            conn.Open();

            return conn;
        });

        public static ShoppingListContext CreateInMemoryDbContext()
        {
            var builder = new DbContextOptionsBuilder<ShoppingListContext>();
            builder.UseSqlite(SqliteConn.Value);

            var context = new ShoppingListContext(builder.Options);
            context.Database.EnsureCreated();

            return context;
        }

        public ShoppingListContext CreateDbContext(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
