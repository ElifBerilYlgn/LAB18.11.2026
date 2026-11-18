using System;
using System.Linq;
using System.Globalization;

class Product
{
    public string ProductCode { get; init; }

    public string Name { get; set; }

    private double price;

    public double Price
    {
        get
        {
            return price;
        }

        set
        {
            if (value > 0)
            {
                price = value;
            }
            else
            {
                Console.WriteLine($"Invalid price: {value}");
                price = 1.0;
            }
        }
    }

    public int Stock { get; private set; }

    public Product(string productCode, string name, double price, int stock)
    {
        ProductCode = productCode;
        Name = name;
        Price = price;
        Stock = stock;
    }

    public void Restock(int amount)
    {
        if (amount > 0)
        {
            Stock += amount;
        }
    }

    public string Info()
    {
        return $"[{ProductCode}] {Name} - ${Price:F2} (Stock: {Stock})";
    }
}

class Program
{
    static void Main()
    {
        
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        
        Product[] products = new Product[]
        {
            new Product("P101", "Wireless Mouse", 25.50, 10),
            new Product("P102", "Mechanical Keyboard", 85.00, 10),
            new Product("P103", "USB-C Cable", -15, 50),
            new Product("P104", "Gaming Monitor", 220.00, 5)
        };

        
        products[0].Restock(5);

        
        foreach (Product product in products)
        {
            Console.WriteLine(product.Info());
        }

        
        double[] prices = new double[products.Length];

        for (int i = 0; i < products.Length; i++)
        {
            prices[i] = products[i].Price;
        }

        Console.WriteLine();

        Console.WriteLine(
            $"Min Price: {prices.Min()} | Max Price: {prices.Max()} | Average: {prices.Average():F2}"
        );

        Console.WriteLine(
            $"Product >= $50: {prices.Count(p => p >= 50)}"
        );

        
        double[] copiedPrices = (double[])prices.Clone();

        
        Array.Sort(copiedPrices);

        Console.WriteLine(
            $"Sorted Prices: {string.Join(" ", copiedPrices)}"
        );

        
        double searchPrice = 85;

        int index = Array.BinarySearch(copiedPrices, searchPrice);

        if (index >= 0)
        {
            Console.WriteLine(
                $"Binary Search for {searchPrice}: Found at Index {index}"
            );
        }
        else
        {
            Console.WriteLine(
                $"Binary Search for {searchPrice}: Not Found"
            );
        }
    }
}
