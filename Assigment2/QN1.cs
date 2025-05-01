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

