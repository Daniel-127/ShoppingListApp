using ShoppingList.Infastructure;
using ShoppingList.Core;

var context = ShoppingListContextFactory.CreateInMemoryDbContext();
var repository = new ProductRepository(context);

while (true)
{
    try
    {
        string input = Console.ReadLine()!;
        var splitInput = input.Split(' ');

        switch (splitInput[0].ToLower())
        {
            case "add":
                var product = new Product(splitInput[1]);
                await repository.CreateAsync(product);
                break;

            case "delete":
                await repository.DeleteAsync(splitInput[1]);
                break;

            case "list":
                var products = await repository.ReadAsync();
                if(products.Count > 0)
                {
                    var print = products.Select(p => p.ToString()).Aggregate((l1, l2) => $"{l1}\n{l2}");
                    Console.WriteLine("\n" + print + "\n");
                }
                break;
            default:
                throw new Exception();
        }
    } 
    catch(Exception) 
    {
        Console.WriteLine("Invaild command");
    }
}


