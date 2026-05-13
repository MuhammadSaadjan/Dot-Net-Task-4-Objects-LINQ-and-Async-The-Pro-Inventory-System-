// Program.cs: Tech Store Inventory System
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
       
        List<Product> inventory = new()
        {
            new Product(1, "MacBook Pro",  2499.99m, 8),
            new Product(2, "Dell Laptop",   349.99m,  3),
            new Product(3, "Samsung 4K Monitor", 799.99m,  12),
            new Product(4, "Logitech Keyboard",   109.99m,  2),
            new Product(5, "Razer Mouse",   69.99m,   20),
            new Product(6, "iPad Pro",    1099.99m, 4),
        };

        // 1. Display All: sorted by Price (High → Low)
        Console.WriteLine("\n ALL PRODUCTS (Price: High → Low)");
        inventory
            .OrderByDescending(p => p.Price)
            .ToList()
            .ForEach(p => Console.WriteLine(
                $"  [{p.Id}] {p.Name,-22} {p.Price,10:C}  Stock: {p.Stock}"));

        // 2. Filter Low Stock (Stock < 5) 
        Console.WriteLine("\n LOW STOCK ALERT (Stock < 5)");
        inventory
            .Where(p => p.Stock < 5)
            .OrderBy(p => p.Stock)
            .ToList()
            .ForEach(p => Console.WriteLine(
                $"  {p.Name,-22}  Only {p.Stock} left!"));

        // 3. Search by name: FirstOrDefault
        //string searchTerm = "iPad Pro";
        Console.Write("\nEnter product name to search: ");
        string searchTerm = Console.ReadLine() ?? string.Empty;
        //Hard Coded value removed and it now takes input from user
        Product? found = inventory
            .FirstOrDefault(p => p.Name.Contains(
                searchTerm, StringComparison.OrdinalIgnoreCase));

        Console.WriteLine($"\n SEARCH: \"{searchTerm}\"");
        Console.WriteLine(found is not null
            ? $"  ✅ Found — {found.Name} at {found.Price:C}"
            : "  ❌ Product not found.");

        // 4. Total Inventory Value: .Sum() 
        decimal totalValue = inventory
            .Sum(p => p.Price * p.Stock);

        Console.WriteLine($"\nTOTAL INVENTORY VALUE: {totalValue:C}");

        // 5. Async cloud save
        await SaveInventoryAsync(inventory);
    }

    static async Task SaveInventoryAsync(List<Product> inventory)
    {
        Console.WriteLine("\nSaving inventory to cloud...");
        await Task.Delay(3000); // non-blocking - UI stays responsive
        Console.WriteLine($"✅ Saved {inventory.Count} products successfully.");
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public Product(int id, string name, decimal price, int stock)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }
}
