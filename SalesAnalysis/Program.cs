using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesAnalysis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create sample sales data
            List<SalesRecord> salesData = GenerateSampleData();

            // Calculate total sales per product
            Console.WriteLine("Total Sales Per Product:");
            var totalSalesPerProduct = CalculateTotalSalesPerProduct(salesData);
            foreach (var item in totalSalesPerProduct)
            {
                Console.WriteLine($"{item.Key}: ${item.Value:F2}");
            }
            Console.WriteLine();

            // Find top 3 best-selling products by quantity
            Console.WriteLine("Top 3 Best-Selling Products (by quantity):");
            var topProducts = FindTopSellingProducts(salesData, 3);
            foreach (var item in topProducts)
            {
                Console.WriteLine($"{item.Key}: {item.Value} units");
            }
            Console.WriteLine();

            // Filter sales for a specific date range
            DateTime startDate = new DateTime(2023, 1, 1);
            DateTime endDate = new DateTime(2023, 3, 31);
            Console.WriteLine($"Sales between {startDate.ToShortDateString()} and {endDate.ToShortDateString()}:");
            
            var filteredSales = FilterSalesByDateRange(salesData, startDate, endDate);
            foreach (var sale in filteredSales)
            {
                Console.WriteLine($"{sale.Date.ToShortDateString()}: {sale.Product} - {sale.Quantity} units at ${sale.Price:F2} each");
            }
        }

        public static Dictionary<string, decimal> CalculateTotalSalesPerProduct(List<SalesRecord> salesData)
        {
            return salesData
                .GroupBy(s => s.Product)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(s => s.Quantity * s.Price)
                );
        }

        public static Dictionary<string, int> FindTopSellingProducts(List<SalesRecord> salesData, int topCount)
        {
            return salesData
                .GroupBy(s => s.Product)
                .OrderBy(g => g.Sum(s => s.Quantity))
                .Take(topCount)
                .ToDictionary(
                    g => g.Key,
                    g => g.Sum(s => s.Quantity)
                );
        }

        public static List<SalesRecord> FilterSalesByDateRange(List<SalesRecord> salesData, DateTime startDate, DateTime endDate)
        {
            return salesData
                .Where(s => s.Date >= startDate && s.Date <= endDate)
                .ToList();
        }

        public static List<SalesRecord> GenerateSampleData()
        {
            return new List<SalesRecord>
            {
                new SalesRecord { Product = "Laptop", Quantity = 5, Price = 1200.00m, Date = new DateTime(2023, 1, 15) },
                new SalesRecord { Product = "Mouse", Quantity = 20, Price = 25.50m, Date = new DateTime(2023, 1, 20) },
                new SalesRecord { Product = "Keyboard", Quantity = 10, Price = 45.99m, Date = new DateTime(2023, 2, 5) },
                new SalesRecord { Product = "Monitor", Quantity = 8, Price = 350.00m, Date = new DateTime(2023, 2, 15) },
                new SalesRecord { Product = "Laptop", Quantity = 3, Price = 1200.00m, Date = new DateTime(2023, 3, 10) },
                new SalesRecord { Product = "Mouse", Quantity = 15, Price = 25.50m, Date = new DateTime(2023, 3, 25) },
                new SalesRecord { Product = "Headphones", Quantity = 12, Price = 75.99m, Date = new DateTime(2023, 4, 5) },
                new SalesRecord { Product = "Laptop", Quantity = 2, Price = 1350.00m, Date = new DateTime(2023, 4, 20) },
                new SalesRecord { Product = "Monitor", Quantity = 5, Price = 350.00m, Date = new DateTime(2023, 5, 10) },
                new SalesRecord { Product = "Keyboard", Quantity = 8, Price = 45.99m, Date = new DateTime(2023, 5, 25) }
            };
        }
    }

    public class SalesRecord
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
