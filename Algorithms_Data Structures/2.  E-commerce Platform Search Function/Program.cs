using System;
using System.Linq;

class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }

    public Product(int id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }

    public override string ToString()
    {
        return ProductId + " - " + ProductName + " (" + Category + ")";
    }
}

class Program
{
    public static Product LinearSearch(Product[] products, string target)
    {
        foreach (Product p in products)
        {
            if (p.ProductName.Equals(target, StringComparison.OrdinalIgnoreCase))
                return p;
        }
        return null;
    }

    public static Product BinarySearch(Product[] products, string target)
    {
        int low = 0, high = products.Length - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            int comparison = string.Compare(products[mid].ProductName, target, true);
            if (comparison == 0) return products[mid];
            else if (comparison < 0) low = mid + 1;
            else high = mid - 1;
        }
        return null;
    }

    static void Main(string[] args)
    {
        Product[] products = {
            new Product(101, "Laptop", "Electronics"),
            new Product(102, "Shampoo", "Personal Care"),
            new Product(103, "Phone", "Electronics"),
            new Product(104, "Notebook", "Stationery"),
            new Product(105, "T-Shirt", "Clothing")
        };

        Console.WriteLine("Linear Search for 'Phone':");
        Product result1 = LinearSearch(products, "Phone");
        if (result1 != null)
            Console.WriteLine("Found: " + result1);
        else
            Console.WriteLine("Product not found");

        var sortedProducts = products.OrderBy(p => p.ProductName.ToLower()).ToArray();

        Console.WriteLine("\nBinary Search for 'Phone':");
        Product result2 = BinarySearch(sortedProducts, "Phone");
        if (result2 != null)
            Console.WriteLine("Found: " + result2);
        else
            Console.WriteLine("Product not found");
    }
}