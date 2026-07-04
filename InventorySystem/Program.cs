using System;
using InventorySystem.Models;
using InventorySystem.Services;

namespace InventorySystem
{
    class Program
    {
        private static readonly Inventory _inventory = new Inventory();

        static void Main(string[] args)
        {
            // Seed some initial data for testing
            SeedData();

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== SMALL SHOP INVENTORY MANAGEMENT ===");
                Console.WriteLine("1. View Current Inventory");
                Console.WriteLine("2. Add New Product");
                Console.WriteLine("3. Update Stock Quantity");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        DisplayInventory();
                        break;
                    case "2":
                        AddNewProduct();
                        break;
                    case "3":
                        UpdateProductStock();
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine("Exiting application. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void SeedData()
        {
            _inventory.AddProduct(new Product("P001", "Coffee Beans (1kg)", 14.99m, 10));
            _inventory.AddProduct(new Product("P002", "Oat Milk (1L)", 3.49m, 2)); // Triggers Restock Alert
            _inventory.AddProduct(new Product("P003", "Paper Cups (100pk)", 8.99m, 5));
        }

        private static void DisplayInventory()
        {
            Console.Clear();
            Console.WriteLine("--- CURRENT INVENTORY ---");
            var products = _inventory.GetAllProducts();

            if (products.Count == 0)
            {
                Console.WriteLine("No products found in stock.");
            }
            else
            {
                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        private static void AddNewProduct()
        {
            Console.Clear();
            Console.WriteLine("--- ADD NEW PRODUCT ---");

            Console.Write("Enter Product ID (e.g., P004): ");
            string id = Console.ReadLine();

            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Price: $");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Invalid price format. Action cancelled.");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter Initial Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int qty))
            {
                Console.WriteLine("Invalid quantity format. Action cancelled.");
                Console.ReadKey();
                return;
            }

            var newProduct = new Product(id, name, price, qty);
            if (_inventory.AddProduct(newProduct))
            {
                Console.WriteLine("\nProduct added successfully!");
            }
            else
            {
                Console.WriteLine("\nError: A product with that ID already exists.");
            }

            Console.ReadKey();
        }

        private static void UpdateProductStock()
        {
            Console.Clear();
            Console.WriteLine("--- UPDATE STOCK QUANTITY ---");

            Console.Write("Enter Product ID: ");
            string id = Console.ReadLine();

            var product = _inventory.FindProduct(id);
            if (product == null)
            {
                Console.WriteLine("Product not found. Press any key to return...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Current Details: {product}");
            Console.Write("Enter adjustment amount (e.g., '5' to restock, '-3' for sales): ");
            
            if (!int.TryParse(Console.ReadLine(), out int amount))
            {
                Console.WriteLine("Invalid amount format. Action cancelled.");
                Console.ReadKey();
                return;
            }

            _inventory.UpdateStock(id, amount);
            Console.WriteLine("\nStock updated successfully!");
            
            // Show new state immediately to demonstrate the Level-Up condition check
            Console.WriteLine($"Updated Details: {product}");
            Console.ReadKey();
        }
    }
}