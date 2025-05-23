using System;
using System.Collections.Generic;

class SalesDetails
{
    static void Main()
    {
        int itemCount = 5;
        List<string> salesmen = new List<string>();  // Our inputs on salesperson ,the data ,number of items andtotal sales will be added here " in code look for e.g salesmen.Add(") function
        List<int[]> salesData = new List<int[]>();
        List<int> totalSales = new List<int>();
        int grandTotal = 0;

        while (true)
        {
            Console.WriteLine("Enter salespersons name /or type no to stop:");
            string name = Console.ReadLine();

            if (name.ToLower() == "no") break; // TOLower will just convert the input to lower case, tuseme ulitype NO or No , for consistency and to avoid errors it will be converted to no , try run and see what i mean 

            salesmen.Add(name);
            int[] sales = new int[itemCount];
            int total = 0;

            for (int j = 0; j < itemCount; j++)
            {
                Console.Write($"Enter sales for {name} (Item N.O {j + 1}): ");
                sales[j] = Convert.ToInt32(Console.ReadLine());
                total += sales[j];

            }

            salesData.Add(sales);
            totalSales.Add(total);
            grandTotal += total;

        }

        Console.WriteLine("\nName\tItem1\tItem2\tItem3\tItem4\tItem5\tTotalSales");
        Console.WriteLine("--------------------------------------------------------"); // This is just for presentability

        for (int s = 0; s < salesmen.Count; s++) // Notice im using Console.Write nikitumia tabs "\t" jaribu na Console.Writeline utapata a vertical list, output inadai horizontal list
        {
            Console.Write($"{salesmen[s]}\t");  // Print name and stay on the same line 

            for (int j = 0; j < itemCount; j++)
            {
                Console.Write($"{salesData[s][j]}\t");  // Print sales data on the same line
            }

            Console.WriteLine($"{totalSales[s]}");  // Move to a new line after all sales are printed
        }

        // Print the final separator and grand total **outside the loop**
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine($"GrandTotal\t{grandTotal}");


    }
}
