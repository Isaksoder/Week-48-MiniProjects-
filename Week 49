using System;
using System.Collections.Generic;
using System.Linq;

namespace Weekly_Mini_Projects_49
{
    class Program
    {
        static void Main(string[] args)
        {
            var assets = new List<Asset>();

            Console.WriteLine("Welcome to the Asset Tracking System!");

            // Input assets
            while (true)
            {
                Console.WriteLine("\nEnter asset details (or type 'done' to finish):");

                Console.Write("Enter Office: ");
                string office = Console.ReadLine();
                if (office.ToLower() == "done") break;

                Console.Write("Enter Asset Type (Computer/Smartphone): ");
                string category = Console.ReadLine();

                Console.Write("Enter Brand: ");
                string brand = Console.ReadLine();

                Console.Write("Enter Model: ");
                string model = Console.ReadLine();

                Console.Write("Enter Purchase Date (yyyy-MM-dd): ");
                DateTime purchaseDate;
                while (!DateTime.TryParse(Console.ReadLine(), out purchaseDate))
                {
                    Console.Write("Invalid date format. Enter again (yyyy-MM-dd): ");
                }

                Console.Write("Enter Price (USD): ");
                decimal priceUSD;
                while (!decimal.TryParse(Console.ReadLine(), out priceUSD))
                {
                    Console.Write("Invalid price. Enter a valid number: ");
                }

                // Create and add asset
                assets.Add(new Asset(office, category, brand, model, purchaseDate, priceUSD));
                Console.WriteLine("Asset added successfully!");
            }

            // Display the assets grouped by office
            Console.WriteLine("\nAsset Tracking System");
            Console.WriteLine(new string('-', 60));

            var groupedAssets = assets
                .OrderBy(a => a.Office)
                .GroupBy(a => a.Office);

            foreach (var officeGroup in groupedAssets)
            {
                Console.WriteLine($"\nOffice: {officeGroup.Key}");
                Console.WriteLine(new string('-', 60));

                foreach (var asset in officeGroup)
                {
                    Console.WriteLine($"Asset: {asset.Category}\n" +
                                      $"Brand: {asset.Brand}\n" +
                                      $"Model: {asset.Model}\n" +
                                      $"Purchase Date: {asset.PurchaseDate:yyyy-MM-dd}\n" +
                                      $"Price (USD): ${asset.PriceUSD}\n");
                }

                Console.WriteLine(new string('-', 60));
            }

            Console.WriteLine("--- End of Asset List ---");
        }
    }

    class Asset
    {
        public string Office { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PriceUSD { get; set; }

        public Asset(string office, string category, string brand, string model, DateTime purchaseDate, decimal priceUSD)
        {
            Office = office;
            Category = category;
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            PriceUSD = priceUSD;
        }
    }
}
