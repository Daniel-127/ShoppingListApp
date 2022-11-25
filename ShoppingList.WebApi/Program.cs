using Microsoft.EntityFrameworkCore;
using ShoppingList.Core;
using ShoppingList.Infastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ShoppingListContext>(options => options.UseSqlite(ShoppingListContextFactory.SqliteConn.Value));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var products = app.MapGroup("/products").WithOpenApi();

products.MapGet("", async (IProductRepository repository) => await repository.ReadAsync());
products.MapPost("", async (Product product, IProductRepository repository) => await repository.CreateAsync(product));
products.MapDelete("/{name}", async (string name, IProductRepository repository) => await repository.DeleteAsync(name));

app.Run();
