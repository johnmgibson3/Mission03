namespace FoodBankInventory
{
    using System;
    using System.Collections.Generic;
    using Mission03;

    class Program
    {
        static List<FoodItem> inventory = new List<FoodItem>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- Food Bank Inventory System ---");
                Console.WriteLine("1. Add Food Item");
                Console.WriteLine("2. Delete Food Item");
                Console.WriteLine("3. Print Current Food Items");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddFoodItem();
                        break;
                    case "2":
                        DeleteFoodItem();
                        break;
                    case "3":
                        PrintFoodItems();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddFoodItem()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Category: ");
            string category = Console.ReadLine();

            Console.Write("Enter Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
            {
                Console.WriteLine("Invalid quantity. Must be a non-negative integer.");
                return;
            }

            // Prompt user for expiration date in separate pieces
            Console.WriteLine("Enter Expiration Date:");
            Console.Write("   Year (YYYY): ");
            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                Console.WriteLine("Invalid year. Try again.");
                return;
            }

            Console.Write("   Month (1-12): ");
            if (!int.TryParse(Console.ReadLine(), out int month) || month < 1 || month > 12)
            {
                Console.WriteLine("Invalid month. Try again.");
                return;
            }

            Console.Write("   Day (1-31): ");
            if (!int.TryParse(Console.ReadLine(), out int day) || day < 1 || day > 31)
            {
                Console.WriteLine("Invalid day. Try again.");
                return;
            }

            // Attempt to construct the DateTime
            DateTime expirationDate;
            try
            {
                expirationDate = new DateTime(year, month, day);
            }
            catch (Exception)
            {
                Console.WriteLine("That date is invalid. Please try again.");
                return;
            }

            try
            {
                FoodItem newItem = new FoodItem(name, category, quantity, expirationDate);
                inventory.Add(newItem);
                Console.WriteLine("Food item added successfully!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DeleteFoodItem()
        {
            Console.Write("Enter the Name of the item to delete: ");
            string nameToDelete = Console.ReadLine();

            var item = inventory.Find(i => i.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                inventory.Remove(item);
                Console.WriteLine($"'{nameToDelete}' removed successfully.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }

        static void PrintFoodItems()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("No items in inventory.");
                return;
            }

            Console.WriteLine("\n--- Current Food Items ---");
            foreach (var item in inventory)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
