using System;

class Business
{
    // These are the properties to store our business numbers
    public double BuyingPrice { get; set; }
    public double TransportCost { get; set; }
    public double SellingPrice { get; set; }

    // Default constructor - sets everything to 0
    public Business()
    {
        BuyingPrice = 0;
        TransportCost = 0;
        SellingPrice = 0;
    }

    // Constructor that lets us set values when creating the object
    public Business(double buy, double transport, double sell)
    {
        BuyingPrice = buy;
        TransportCost = transport;
        SellingPrice = sell;
    }

    // Method to calculate and display profit or loss
    public void CalculateProfitOrLoss()
    {
        // Calculate total cost (buying + transport)
        double totalCost = BuyingPrice + TransportCost;
        
        // Calculate the difference between selling price and total cost
        double difference = SellingPrice - totalCost;

        // Check if it's profit or loss
        if (difference > 0)
        {
            Console.WriteLine($"You made a PROFIT of {difference:C}");
        }
        else if (difference < 0)
        {
            Console.WriteLine($"You made a LOSS of {Math.Abs(difference):C}");
        }
        else
        {
            Console.WriteLine("You broke even - no profit, no loss");
        }
    }
}

class Program
{
    static void Main()
    {
        // Example using the constructor that sets values
        Business item1 = new Business(100, 20, 150);
        item1.CalculateProfitOrLoss();

        // Example using default constructor and setting values later
        Business item2 = new Business();
        item2.BuyingPrice = 200;
        item2.TransportCost = 30;
        item2.SellingPrice = 180;
        item2.CalculateProfitOrLoss();
    }
}
