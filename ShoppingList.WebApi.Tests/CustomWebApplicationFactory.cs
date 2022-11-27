using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingList.Infastructure;

namespace ShoppingList.WebApi.Tests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Development");
        }

        public async Task InitializeAsync()
        {
            using var scope = Services.CreateAsyncScope();
            using var context = scope.ServiceProvider.GetRequiredService<ShoppingListContext>();

            var p1 = new Product("Apple").Convert();
            var p2 = new Product("Orange").Convert();
            context.Products.AddRange(p1, p2);
            
            await context.SaveChangesAsync();
        }

        async Task IAsyncLifetime.DisposeAsync()
        {
            using var scope = Services.CreateAsyncScope();
            using var context = scope.ServiceProvider.GetRequiredService<ShoppingListContext>();

            await context.Database.EnsureDeletedAsync();
        }
    }
}
