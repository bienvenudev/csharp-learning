using System;
using System.Collections.Generic;

public class InventoryManagement
{
    public static void Main(string[] args){
        List<string> inventoryList = new List<string> {"Printer", "Laptop", "Desk Chair", "Monitor", "Keyboard"};

        Console.WriteLine(inventoryList.Count);
        bool hasDeskChair = inventoryList.Contains("Desk Chair");
        bool removed = inventoryList.Remove("Printer");
    
        foreach (string inventory in inventoryList) 
        {
            Console.WriteLine(inventory);
        }

        List<string> newItems = new List<string> {"Mouse", "Desk Lamp"};

        inventoryList.AddRange(newItems);
        Console.WriteLine(inventoryList.Count);
        inventoryList.RemoveRange(inventoryList.Count - 2, 2);

        List<string> topInventory = inventoryList.Count >= 3 ? inventoryList.GetRange(0, 3) : new List<string>(inventoryList);
        
        foreach (string item in topInventory) 
        {
            Console.WriteLine(item);
        }
    }
}