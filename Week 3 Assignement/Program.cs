using System;
using System.Collections.Generic;

namespace InventoryManagementApp
{
    class Program
    {
        //initialising 2 dictionary for inventory and sales dataset
        static Dictionary<string, int> inventory = new Dictionary<string, int>();
        static Dictionary<string, int> sales     = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            // Initialize dictionaries with sample data
            inventory.Add("Novels", 100);
            inventory.Add("Science Books", 130);

            sales.Add("Novels", 0);
            sales.Add("Science Books", 0);

            //main block for selecting options
            try
            {
                while (true)
                {
                    Console.WriteLine("1. Input Sales and Restock Data");
                    Console.WriteLine("2. Display Inventory Status");
                    Console.WriteLine("3. Exit");

                    Console.Write("Choose an option: ");
                    int option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            InputSalesAndRestockData();
                            break;
                        case 2:
                            DisplayInventoryStatus();
                            break;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("Invalid. Please choose a valid option.");
                            break;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error occured. Please retry.");
            }
        }

        static void InputSalesAndRestockData()
        {
            try
            {
                //read input from console
                Console.Write("Enter number of novels sold: ");
                int novelsSold = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter number of science books sold: ");
                int scienceBooksSold = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter number of novels restocked: ");
                int novelsRestocked = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter number of science books restocked: ");
                int scienceBooksRestocked = Convert.ToInt32(Console.ReadLine());

                // Validate input data
                if (novelsSold < 0 || scienceBooksSold < 0 || novelsRestocked < 0 || scienceBooksRestocked < 0)
                {
                    Console.WriteLine("Invalid input. Please enter valid numbers.");
                    return;
                }

                // Update inventory levels
                UpdateInventoryLevels(novelsSold, scienceBooksSold, novelsRestocked, scienceBooksRestocked);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please enter a valid number.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured. Please retry.");
            }
        }

        static void UpdateInventoryLevels(int novelsSold = 0, int scienceBooksSold = 0, int novelsRestocked = 0, int scienceBooksRestocked = 0)
        {
            try
            {
                // Update inventory levels based on sales and restocking
                inventory["Novels"] -= novelsSold;
                inventory["Science Books"] -= scienceBooksSold;
                inventory["Novels"] += novelsRestocked;
                inventory["Science Books"] += scienceBooksRestocked;

                Console.WriteLine("Inventory levels saved successfully!");

                // Update sales count
                sales["Novels"] += novelsSold;
                sales["Science Books"] += scienceBooksSold;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured while updating. Please retry.");
            }
        }

        static void DisplayInventoryStatus()
        {
            //to display inventory levels
            Console.WriteLine("--------------Current Inventory Levels-----------\n");
            foreach (var item in inventory)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            //to display sales info
            Console.WriteLine("--------------Recent Sales trend-----------------\n");
            foreach (var item in sales)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}