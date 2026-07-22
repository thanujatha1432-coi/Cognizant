using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.Models;

using AppDbContext context = new();

Console.WriteLine("Lab 4: Inserting Initial Data into the Database");
Console.WriteLine();

if (await context.Products.AnyAsync())
{
    Console.WriteLine("Initial data already exists.");
    return;
}

Category electronics = new()
{
    Name = "Electronics"
};

Category groceries = new()
{
    Name = "Groceries"
};

await context.Categories.AddRangeAsync(electronics, groceries);

Product product1 = new()
{
    Name = "Laptop",
    Price = 75000,
    Category = electronics
};

Product product2 = new()
{
    Name = "Rice Bag",
    Price = 1200,
    Category = groceries
};

await context.Products.AddRangeAsync(product1, product2);

await context.SaveChangesAsync();

Console.WriteLine("Categories and products inserted successfully.");
Console.WriteLine("Electronics - Laptop - ₹75000");
Console.WriteLine("Groceries - Rice Bag - ₹1200");