using System;
using System.Collections.Generic;

public class Order
{
    public int OrderId;
    public string CustomerName;
    public double TotalPrice;

    public Order(int orderId, string customerName, double totalPrice)
    {
        OrderId = orderId;
        CustomerName = customerName;
        TotalPrice = totalPrice;
    }

    public void Display()
    {
        Console.WriteLine($"OrderID: {OrderId}, Customer: {CustomerName}, TotalPrice: {TotalPrice}");
    }
}

public class OrderSorter
{
    
    public static void BubbleSort(List<Order> orders)
    {
        int n = orders.Count;
        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (orders[j].TotalPrice > orders[j + 1].TotalPrice)
                {
                    var temp = orders[j];
                    orders[j] = orders[j + 1];
                    orders[j + 1] = temp;
                    swapped = true;
                }
            }
            if (!swapped)
                break;
        }
    }

    
    public static void QuickSort(List<Order> orders, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(orders, low, high);
            QuickSort(orders, low, pi - 1);
            QuickSort(orders, pi + 1, high);
        }
    }

    private static int Partition(List<Order> orders, int low, int high)
    {
        double pivot = orders[high].TotalPrice;
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (orders[j].TotalPrice <= pivot)
            {
                i++;
                var temp = orders[i];
                orders[i] = orders[j];
                orders[j] = temp;
            }
        }

        var swap = orders[i + 1];
        orders[i + 1] = orders[high];
        orders[high] = swap;

        return i + 1;
    }

    public static void DisplayOrders(string label, List<Order> orders)
    {
        Console.WriteLine($"\n{label}");
        foreach (var order in orders)
        {
            order.Display();
        }
    }
}

class Program
{
    static void Main()
    {
        List<Order> orders = new List<Order>
        {
            new Order(101, "Alice", 450.50),
            new Order(102, "Bob", 1200.00),
            new Order(103, "Charlie", 650.75),
            new Order(104, "David", 200.25),
            new Order(105, "Eva", 950.00)
        };

        
        List<Order> bubbleSortedOrders = new List<Order>(orders);
        List<Order> quickSortedOrders = new List<Order>(orders);

        
        OrderSorter.BubbleSort(bubbleSortedOrders);
        OrderSorter.DisplayOrders("Orders Sorted by Bubble Sort:", bubbleSortedOrders);

        
        OrderSorter.QuickSort(quickSortedOrders, 0, quickSortedOrders.Count - 1);
        OrderSorter.DisplayOrders("Orders Sorted by Quick Sort:", quickSortedOrders);
    }
}