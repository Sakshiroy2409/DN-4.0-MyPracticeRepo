using System;
using System.Collections.Generic;

public class Product
{
    public int ProductId;
    public string ProductName;
    public int Quantity;
    public double Price;

    public Product(int productId, string productName, int quantity, double price)
    {
        ProductId = productId;
        ProductName = productName;
        Quantity = quantity;
        Price = price;
    }

    public void Display()
    {
        Console.WriteLine($"ID: {ProductId}, Name: {ProductName}, Quantity: {Quantity}, Price: {Price}");
    }
}

public class InventoryManagementSystem
{
    private Dictionary<int, Product> inventory;

    public InventoryManagementSystem()
    {
        inventory = new Dictionary<int, Product>();
    }

    
    public void AddProduct(Product p)
    {
        if (!inventory.ContainsKey(p.ProductId))
        {
            inventory[p.ProductId] = p;
            Console.WriteLine("Product added.");
        }
        else
        {
            Console.WriteLine("Product ID already exists.");
        }
    }

    
    public void UpdateProduct(int id, string name, int quantity, double price)
    {
        if (inventory.ContainsKey(id))
        {
            inventory[id].ProductName = name;
            inventory[id].Quantity = quantity;
            inventory[id].Price = price;
            Console.WriteLine("Product updated.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    
    public void DeleteProduct(int id)
    {
        if (inventory.ContainsKey(id))
        {
            inventory.Remove(id);
            Console.WriteLine("Product deleted.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    
    public void DisplayAll()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("No products in inventory.");
            return;
        }

        foreach (var product in inventory.Values)
        {
            product.Display();
        }
    }
}

class Program
{
    static void Main()
    {
        InventoryManagementSystem ims = new InventoryManagementSystem();

        
        ims.AddProduct(new Product(1, "Laptop", 10, 50000));
        ims.AddProduct(new Product(2, "Mouse", 50, 500));
        ims.AddProduct(new Product(3, "Keyboard", 20, 1000));

        Console.WriteLine("\nAll Products:");
        ims.DisplayAll();

        
        Console.WriteLine("\nUpdating Product ID 2:");
        ims.UpdateProduct(2, "Wireless Mouse", 40, 700);

        Console.WriteLine("\nAll Products After Update:");
        ims.DisplayAll();

        
        Console.WriteLine("\nDeleting Product ID 1:");
        ims.DeleteProduct(1);

        Console.WriteLine("\nAll Products After Deletion:");
        ims.DisplayAll();
    }
}