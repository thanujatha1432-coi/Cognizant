using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.Models;

using AppDbContext context = new();

Console.WriteLine("Lab 5: Retrieving Data from the Database");
Console.WriteLine();

List<Product> products = await context.Products.ToListAsync();

Console.WriteLine("All Products:");

foreach (Product product in products)
{
    Console.WriteLine($"{product.Name} - ₹{product.Price}");
}

Console.WriteLine();

Product? foundProduct = await context.Products.FindAsync(1);

Console.WriteLine($"Found: {foundProduct?.Name}");

Console.WriteLine();

Product? expensiveProduct = await context.Products
    .FirstOrDefaultAsync(product => product.Price > 50000);

Console.WriteLine($"Expensive: {expensiveProduct?.Name}");