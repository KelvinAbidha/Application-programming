using System;

// Abstract base class
public abstract class Business
{
    // Public properties
    public double BuyingPrice { get; set; }
    public double TransportCost { get; set; }
    public double SellingPrice { get; set; }

    // Protected fields for use in derived classes
    protected double buyingPrice;
    protected double transportCost;
    protected double sellingPrice;

    // Default constructor
    public Business()
    {
        BuyingPrice = 0;
        TransportCost = 0;
        SellingPrice = 0;
        buyingPrice = 0;
        transportCost = 0;
        sellingPrice = 0;
    }

    // Parameterized constructor
    public Business(double buyingPrice, double transportCost, double sellingPrice)
    {
        ValidateInput(buyingPrice, transportCost, sellingPrice);

        BuyingPrice = buyingPrice;
        TransportCost = transportCost;
        SellingPrice = sellingPrice;

        this.buyingPrice = buyingPrice;
        this.transportCost = transportCost;
        this.sellingPrice = sellingPrice;
    }

    // Input validation method
    private void ValidateInput(double buyingPrice, double transportCost, double sellingPrice)
    {
        if (buyingPrice < 0 || transportCost < 0 || sellingPrice < 0)
            throw new ArgumentException("Prices and costs cannot be negative.");
    }

    // Abstract method to be implemented by subclasses
    public abstract void CalculateProfitOrLoss();
}

// Retail business class
public class RetailBusiness : Business
{
    public RetailBusiness() : base() { }

    public RetailBusiness(double buyingPrice, double transportCost, double sellingPrice)
        : base(buyingPrice, transportCost, sellingPrice) { }

    public override void CalculateProfitOrLoss()
    {
        double totalCost = buyingPrice + transportCost;
        double result = sellingPrice - totalCost;

        if (result > 0)
        {
            Console.WriteLine($"[Retail] A PROFIT of ${result:F2} was made.");
        }
        else if (result < 0)
        {
            Console.WriteLine($"[Retail] A LOSS of ${Math.Abs(result):F2} was incurred.");
        }
        else
        {
            Console.WriteLine("[Retail] You broke even - no profit, no loss.");
        }
    }
}

// Wholesale business class
public class WholesaleBusiness : Business
{
    private const double WholesaleDiscount = 0.1;

    public WholesaleBusiness() : base() { }

    public WholesaleBusiness(double buyingPrice, double transportCost, double sellingPrice)
        : base(buyingPrice, transportCost, sellingPrice) { }

    public override void CalculateProfitOrLoss()
    {
        double discountedSellingPrice = sellingPrice * (1 - WholesaleDiscount);
        double totalCost = buyingPrice + transportCost;
        double result = discountedSellingPrice - totalCost;

        if (result > 0)
        {
            Console.WriteLine($"[Wholesale] A PROFIT of ${result:F2} was made after {WholesaleDiscount * 100}% discount.");
        }
        else if (result < 0)
        {
            Console.WriteLine($"[Wholesale] A LOSS of ${Math.Abs(result):F2} was incurred after {WholesaleDiscount * 100}% discount.");
        }
        else
        {
            Console.WriteLine("[Wholesale] You broke even after discount.");
        }
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Test Retail Business
            Console.WriteLine("Enter details for Retail Business:");
            Console.Write("Enter buying price: ");
            double buy = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter transport cost: ");
            double transport = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter selling price: ");
            double sell = Convert.ToDouble(Console.ReadLine());

            Business retail = new RetailBusiness(buy, transport, sell);
            retail.CalculateProfitOrLoss();

            // Test Wholesale Business
            Console.WriteLine("\nEnter details for Wholesale Business:");
            Console.Write("Enter buying price: ");
            buy = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter transport cost: ");
            transport = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter selling price: ");
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
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}
