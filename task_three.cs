using System;

class CreditEvaluator
{
    static void Main()
    {
        Console.Write("Enter number of customers: ");
        int customers = int.Parse(Console.ReadLine());

        for (int i = 0; i < customers; i++)
        {
            Console.Write("Enter credit limit: ");
            double creditLimit = double.Parse(Console.ReadLine());

            Console.Write("Enter price of the item: ");
            double price = double.Parse(Console.ReadLine());

            double totalValue;
            do
            {
                Console.Write("Enter quantity of the item: ");
                int quantity = int.Parse(Console.ReadLine());

                totalValue = price * quantity;

                if (totalValue > creditLimit)
                {
                    Console.WriteLine("Sorry you cannot purchase goods worthy such a value on credit.");
                }
                else
                {
                    Console.WriteLine("Thank You for purchasing from us. The value of the purchase is " + totalValue);
                }
            } while (totalValue > creditLimit);
        }
    }
}