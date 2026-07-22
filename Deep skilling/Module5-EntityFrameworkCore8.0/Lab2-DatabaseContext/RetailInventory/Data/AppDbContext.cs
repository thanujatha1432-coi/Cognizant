using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

namespace RetailInventory.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();

    public DbSet<Category> Categories => Set<Category>();

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
    @"Server=localhost\SQLEXPRESS01;Database=RetailInventoryLab3Db;Trusted_Connection=True;TrustServerCertificate=True;");
}
}