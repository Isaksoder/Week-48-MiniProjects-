using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductListApp
{
    public class Product
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Category,-15} {Name,-20} {Price,10:C}";
        }
    }

    class Program
    {
        static List<Product> products = new List<Product>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Product List App!");
            bool exit = false;

            while (!exit)
            {
                AddProducts();
                Console.Clear();

                Console.WriteLine("\nYour Products:");
                DisplayProducts();

                // Option to search or quit
                bool continueSearching = true;
                while (continueSearching)
                {
                    Console.WriteLine("\nWould you like to (1) Search for an item or (2) Quit? Enter 1 or 2:");
                    string option = Console.ReadLine();
                    if (option == "1")
                    {
                        SearchProducts();
                    }
                    else if (option == "2")
                    {
                        continueSearching = false;
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Please enter 1 to search or 2 to quit.");
                    }
                }
            }
        }

        static void AddProducts()
        {
            Console.WriteLine("\nTo enter a new product, please provide the following information:");

            while (true)
            {
                try
                {
                    Console.Write("Enter Category: ");
                    string category = Console.ReadLine();
                    if (category.ToLower() == "q") break;

                    Console.Write("Enter Product Name: ");
                    string name = Console.ReadLine();
                    if (name.ToLower() == "q") break;

                    Console.Write("Enter Price: ");
                    string priceInput = Console.ReadLine();
                    if (priceInput.ToLower() == "q") break;

                    if (!decimal.TryParse(priceInput, out decimal price) || price < 0)
                    {
                        Console.WriteLine("Invalid price! Please enter a positive number.");
                        continue;
                    }

                    // Add product to the list
                    products.Add(new Product { Category = category, Name = name, Price = price });

                    // Success message
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The product was successfully added!");
                    Console.ResetColor();

                    // Prompt for next step
                    Console.WriteLine("\nTo enter a new product, please provide the following information.");
                    Console.WriteLine("Or type 'q' to quit and see your list.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static void DisplayProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products to display.");
                return;
            }

            Console.WriteLine($"{"Category",-15} {"Product Name",-20} {"Price",10}");
            Console.WriteLine(new string('-', 50));

            // LINQ: Sort and display products
            var sortedProducts = products.OrderBy(p => p.Price).ToList();
            foreach (var product in sortedProducts)
            {
                Console.WriteLine(product);
            }

            // Display total price
            decimal totalPrice = sortedProducts.Sum(p => p.Price);
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"{"Total",-35} {totalPrice,10:C}");
        }

        static void SearchProducts()
        {
            Console.WriteLine("\nEnter the product name or category to search:");
            string searchQuery = Console.ReadLine()?.ToLower();

            var searchResults = products
                .Where(p => p.Name.ToLower().Contains(searchQuery) || p.Category.ToLower().Contains(searchQuery))
                .ToList();

            if (searchResults.Count > 0)
            {
                Console.WriteLine("\nSearch Results:");
                Console.WriteLine($"{"Category",-15} {"Product Name",-20} {"Price",10}");
                Console.WriteLine(new string('-', 50));
                foreach (var product in searchResults)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // Highlight matching items
                    Console.WriteLine(product);
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("\nNo products match your search query.");
            }
        }
    }
}
