using System;
using System.Collections.Generic;

namespace Lab3._2
{
    class Program
    {
        public static void FinalScreen(List<string> listItem, List<decimal> cost)
        {
            string s;
            decimal average = 0;
            Console.WriteLine("Item            Price");
            Console.WriteLine("==========================");
            for (int i = 0; i < listItem.Count; i++)
            {
                s = String.Format("| {0,-16}${1,4}  |", listItem[i], cost[i]);
                Console.WriteLine(s);
                average += cost[i];
            }
            average /= listItem.Count;
            Console.WriteLine("==========================\n\n");
            Console.WriteLine("The average cost of all items is ${0}\n\n\n\n", average);

        }
        public static string FindAndDisplay(Dictionary<string, decimal> menu, int itemSelected)
        {
            int x = 0;
            foreach (var menuItem in menu)
                {
                x++;
                if (x == itemSelected)
                    {
                    Console.WriteLine($"\nYou have added {menuItem.Key} to your cart at a cost of ${menuItem.Value}.");
                    return menuItem.Key;
                    }
                
                }
            return "";
        }

        public static void DisplayMenu(Dictionary<string, decimal> menu)
        {
            string s;
            int count = 0;
            Console.WriteLine("\nThis is not the greatest \n\tstore in the world no,");
            Console.WriteLine("\t\tthis is a tribute!\n");

            Console.WriteLine("Selection       Item            Price");
            Console.WriteLine("========================================");
            foreach (var menuItem in menu)
            {
                count++;
                s = String.Format("| {0,-14}{1,-16}${2,4}  |", count, menuItem.Key, menuItem.Value);
                Console.WriteLine(s);
            }
            Console.WriteLine("========================================");
        }
        static void Main(string[] args)
        {
            List<string> customerItems = new List<string>();
            List<decimal> itemCost = new List<decimal>();
            Dictionary<string, decimal> menuItems = new Dictionary<string, decimal>();
            menuItems["Apple"] = 0.99m;
            menuItems["Banana"] = 0.59m;
            menuItems["Cauliflower"] = 1.59m;
            menuItems["Dragonfruit"] = 2.19m;
            menuItems["Elderberry"] = 1.79m;
            menuItems["Figs"] = 2.09m;
            menuItems["Grapefruit"] = 1.99m;
            menuItems["Honeydew"] = 3.49m;
            string strSelection;
            int selection = 0;
            string addItem;
            string addMore;
            bool cont = true;

            while (cont == true)
            {
                Console.Clear();
            DisplayMenu(menuItems);

            while (selection < 1 || selection > 8)
            {
                if (selection == -1)
                    Console.WriteLine("Invalid entry, Please enter a selection bteween 1-8: ");
                selection = -1;
                Console.Write("\nPlease enter the selection number for your next item: ");
                strSelection = Console.ReadLine();
                Int32.TryParse(strSelection, out selection);
            }

            addItem = FindAndDisplay(menuItems, selection);
            customerItems.Add(addItem);
            itemCost.Add(menuItems[addItem]);
            selection = 0;
            do
            {
                Console.Write("\nWould you like to add another item? y/n: ");
                addMore = Console.ReadLine().ToLower();
                if (addMore == "n")
                    cont = false;
            } while (addMore != "y" && addMore != "n");
        }
            Console.Clear();
            Console.WriteLine("\nThis is a trubute! Have a nice day!\n\n");
            FinalScreen(customerItems, itemCost);
        }
    }
}