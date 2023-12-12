using System;
using System.Collections.Generic;
 
public class Program
{
    public static void Main()
    {
        // Prompt the user to enter the number of items
        Console.Write("Enter the number of items: ");
        int numberOfItems = int.Parse(Console.ReadLine());
 
        // Create a list to store the items
        List<Item> items = new List<Item>();
 
        // Loop to get input for each item
        for (int i = 1; i <= numberOfItems; i++)
        {
            Console.WriteLine($"Enter details for item {i}:");
 
            Console.Write("Name: ");
            string itemName = Console.ReadLine();
 
            Console.Write("Price: ");
            double itemPrice = double.Parse(Console.ReadLine());
 
            Console.Write("Is exempt from sales tax? (true/false): ");
            bool isExempt = bool.Parse(Console.ReadLine());
 
            Console.Write("Is imported? (true/false): ");
            bool isImported = bool.Parse(Console.ReadLine());
 
            // Add the item to the list
            items.Add(new Item { Name = itemName, Price = itemPrice, IsExempt = isExempt, IsImported = isImported });
        }
 
        // Call the PrintReceipt method with the user-input items
        PrintReceipt(items);
    }
 
    public static void PrintReceipt(List<Item> items)
    {
        var totalSalesTax = 0.0;
        var totalAmount = 0.0;
 
        foreach (var item in items)
        {
            var taxRate = item.IsImported ? 5 : 10;
            var taxAmount = item.IsExempt ? 0 : (item.Price * taxRate / 100).RoundUp(0.05);
            var itemTotal = item.Price + taxAmount;
 
            Console.WriteLine($"{item.Name}: {itemTotal.ToString("0.00")}");
            totalSalesTax += taxAmount;
            totalAmount += itemTotal;
        }
 
        Console.WriteLine($"Sales Taxes: {totalSalesTax.ToString("0.00")}");
        Console.WriteLine($"Total: {totalAmount.ToString("0.00")}");
        Console.WriteLine();
    }
}
 
public class Item
{
    public string Name { get; set; }
    public double Price { get; set; }
    public bool IsExempt { get; set; }
    public bool IsImported { get; set; }
}
 
public static class DoubleExtensions
{
    public static double RoundUp(this double number, double multiple)
    {
        var rem = number % multiple;
        if (rem != 0)
        {
            return number + multiple - rem;
        }
        return number;
    }
}

