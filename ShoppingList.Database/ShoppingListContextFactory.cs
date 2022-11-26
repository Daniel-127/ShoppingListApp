using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ShoppingList.Infastructure
{
    public class ShoppingListContextFactory : IDesignTimeDbContextFactory<ShoppingListContext>
    {
        public readonly static Lazy<SqliteConnection> SqliteConn = new Lazy<SqliteConnection>(() => 
        {
            var conn = new SqliteConnection("Filename=:memory:");
            conn.Open();

            var builder = new DbContextOptionsBuilder<ShoppingListContext>();
            builder.UseSqlite(conn);

            var context = new ShoppingListContext(builder.Options);
            context.Database.EnsureCreated();

            return conn;
        });

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

        public ShoppingListContext CreateDbContext(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
