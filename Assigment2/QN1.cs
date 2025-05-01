/* 
Implemented Encapsulation deeclaring class as private ,to be used by derived class of Buisness.Require getters and setters to access data 
Defualt connstructor no parameters , set everything to 0
Output will be :
"You made a Profit of 30 "for object we creatd 
"You made a Loss of 50" From the default constructor 
*/

using System;

class Business
{
    // Attributes of Buisness store , { get; set; } indicates these are auto-implemented properties
   
    public double BuyingPrice { get; set; }
    public double TransportCost { get; set; }
    public double SellingPrice { get; set; }

    // Default constructor , " a default constructor that initializes these values to 0 " as per instructions 
    public Business()
    {
        BuyingPrice = 0;
        TransportCost = 0;
        SellingPrice = 0;
    }

    // Constructor with parameters , if parameters and instance of fields had same name we use "this." to differentiate the two but in this case its not necessary
    public Business(double buy, double transport, double sell)
    {
        BuyingPrice = buy;
        TransportCost = transport;
        SellingPrice = sell;
    }

    // Method to calculate and display profit or loss , to be called in the main by an object created 
    public void CalculateProfitOrLoss()
    {
        // Calculate total cost (buying + transport)
        double totalCost = BuyingPrice + TransportCost;
        
        // Calculate the difference between selling price and total cost
        double difference = SellingPrice - totalCost;

        /* Check if it's profit or loss , not the "C" its a format specifier used to convert value to currency u can replace it with F2 which 
        is a fixed point notation that formats to two decimal places  */
        if (difference > 0) // profit made
        {
            Console.WriteLine($"You made a PROFIT of {difference:C}");
        }
        else if (difference < 0) //Loss made 
        {
            Console.WriteLine($"You made a LOSS of {Math.Abs(difference):C}"); // Math.abs maks sure value is absolute as output incase loss is a negative number 
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
        //Creating an object of the class Buisness
        Business item1 = new Business(100, 20, 150); // NOTE Number of parameters should be the same when passed
        item1.CalculateProfitOrLoss(); // Calling the method to calculate profit or Loss

        // Example using default constructor and setting values later
        Business item2 = new Business();
        item2.BuyingPrice = 200;
        item2.TransportCost = 30;
        item2.SellingPrice = 180;
        item2.CalculateProfitOrLoss();
    }
}
