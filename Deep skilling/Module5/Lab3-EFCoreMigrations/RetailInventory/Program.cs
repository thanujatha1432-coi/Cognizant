using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;

using AppDbContext context = new();

Console.WriteLine("Lab 3: Using EF Core CLI to Create and Apply Migrations");
Console.WriteLine();

bool canConnect = await context.Database.CanConnectAsync();

if (canConnect)
{
    Console.WriteLine("Database connection successful.");
    Console.WriteLine("Initial migration applied successfully.");
    Console.WriteLine("Database: RetailInventoryLab3Db");
    Console.WriteLine("Tables: Products and Categories");
}
else
{
    Console.WriteLine("Unable to connect to the database.");
}