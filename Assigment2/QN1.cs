using System;

// Abstract base class for abstraction
public abstract class Business
{
    protected double buyingPrice;
    protected double transportCost;
    protected double sellingPrice;

    // Default constructor
    public Business()
    {
        buyingPrice = 0;
        transportCost = 0;
        sellingPrice = 0;
    }

    // Parameterized constructor
    public Business(double buyingPrice, double transportCost, double sellingPrice)
    {
        ValidateInput(buyingPrice, transportCost, sellingPrice);
        this.buyingPrice = buyingPrice;
        this.transportCost = transportCost;
        this.sellingPrice = sellingPrice;
    }

    // Input validation
    private void ValidateInput(double buyingPrice, double transportCost, double sellingPrice)
    {
        if (buyingPrice < 0 || transportCost < 0 || sellingPrice < 0)
            throw new ArgumentException("Prices and costs cannot be negative.");
    }

    // Abstract method for polymorphism
    public abstract void CalculateProfitOrLoss();
}

// Derived class for Retail business
public class RetailBusiness : Business
{
    public RetailBusiness() : base() { }
    public RetailBusiness(double buyingPrice, double transportCost, double sellingPrice)
        : base(buyingPrice, transportCost, sellingPrice) { }

    // Override for polymorphic behavior
    public override void CalculateProfitOrLoss()
    {
        double totalCost = buyingPrice + transportCost;
        double result = sellingPrice - totalCost;

        if (result > 0)
        {
            Console.WriteLine($"[Retail] A profit of ${result:F2} was made.");
        }
        else if (result < 0)
        {
            Console.WriteLine($"[Retail] A loss of ${Math.Abs(result):F2} was incurred.");
        }
        else
        {
            Console.WriteLine("[Retail] No profit or loss was made.");
        }
    }
}

// Derived class for Wholesale business (different calculation)
public class WholesaleBusiness : Business
{
    private const double WholesaleDiscount = 0.1; // 10% discount on selling price

    public WholesaleBusiness() : base() { }
    public WholesaleBusiness(double buyingPrice, double transportCost, double sellingPrice)
        : base(buyingPrice, transportCost, sellingPrice) { }

    // Override for polymorphic behavior
    public override void CalculateProfitOrLoss()
    {
        double discountedSellingPrice = sellingPrice * (1 - WholesaleDiscount);
        double totalCost = buyingPrice + transportCost;
        double result = discountedSellingPrice - totalCost;

        if (result > 0)
        {
            Console.WriteLine($"[Wholesale] A profit of ${result:F2} was made after {WholesaleDiscount*100}% discount.");
        }
        else if (result < 0)
        {
            Console.WriteLine($"[Wholesale] A loss of ${Math.Abs(result):F2} was incurred after {WholesaleDiscount*100}% discount.");
        }
        else
        {
            Console.WriteLine("[Wholesale] No profit or loss was made after discount.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Test Retail Business
            Console.WriteLine("Enter details for Retail Business:");
            Console.WriteLine("Enter buying price:");
            double buy = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter transport cost:");
            double transport = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter selling price:");
            double sell = Convert.ToDouble(Console.ReadLine());

            Business retail = new RetailBusiness(buy, transport, sell);
            retail.CalculateProfitOrLoss();

            // Test Wholesale Business
            Console.WriteLine("\nEnter details for Wholesale Business:");
            Console.WriteLine("Enter buying price:");
            buy = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter transport cost:");
            transport = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter selling price:");
            sell = Convert.ToDouble(Console.ReadLine());

            Business wholesale = new WholesaleBusiness(buy, transport, sell);
            wholesale.CalculateProfitOrLoss();

            // Test default constructor
            Console.WriteLine("\nTesting default constructor with Retail Business:");
            Business defaultRetail = new RetailBusiness();
            defaultRetail.CalculateProfitOrLoss();
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter valid numeric values.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}
