using System;

class Product
{
    public int ProductId;
    public string ProductName;
    public string Category;

    public Product(int id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }
}

class SearchFunction
{
    // Linear Search
    public static Product? LinearSearch(Product[] products, int id)
    {
        foreach (Product product in products)
        {
            if (product.ProductId == id)
            {
                return product;
            }
        }

        return null;
    }

    // Binary Search
    public static Product? BinarySearch(Product[] products, int id)
    {
        int low = 0;
        int high = products.Length - 1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;

            if (products[mid].ProductId == id)
            {
                return products[mid];
            }

            if (products[mid].ProductId < id)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return null;
    }
}

class Program
{
    static void Main()
    {
        Product[] products =
        {
            new Product(101, "Laptop", "Electronics"),
            new Product(102, "Mobile", "Electronics"),
            new Product(103, "Shoes", "Fashion"),
            new Product(104, "Watch", "Accessories"),
            new Product(105, "Headphones", "Electronics")
        };

        Console.WriteLine("=== E-Commerce Platform Search Function ===");
        Console.Write("Enter Product ID to Search: ");

        bool isValid = int.TryParse(Console.ReadLine(), out int id);

        if (!isValid)
        {
            Console.WriteLine("Please enter a valid Product ID.");
            return;
        }

        Product? linearResult = SearchFunction.LinearSearch(products, id);

        Console.WriteLine("\nLinear Search Result:");

        if (linearResult != null)
        {
            Console.WriteLine("Product ID   : " + linearResult.ProductId);
            Console.WriteLine("Product Name : " + linearResult.ProductName);
            Console.WriteLine("Category     : " + linearResult.Category);
        }
        else
        {
            Console.WriteLine("Product Not Found");
        }

        Product? binaryResult = SearchFunction.BinarySearch(products, id);

        Console.WriteLine("\nBinary Search Result:");

        if (binaryResult != null)
        {
            Console.WriteLine("Product ID   : " + binaryResult.ProductId);
            Console.WriteLine("Product Name : " + binaryResult.ProductName);
            Console.WriteLine("Category     : " + binaryResult.Category);
        }
        else
        {
            Console.WriteLine("Product Not Found");
        }

        Console.WriteLine("\nTime Complexity:");
        Console.WriteLine("Linear Search : O(n)");
        Console.WriteLine("Binary Search : O(log n)");
    }
}