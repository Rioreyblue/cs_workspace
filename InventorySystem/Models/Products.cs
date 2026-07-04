using System;

namespace InventorySystem.Models
{
    public class Product
    {
        // Properties
        public string Id { get; private set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; private set; }

        // Level-Up: Restock Alert Threshold
        private const int RestockThreshold = 3;

        // Constructor
        public Product(string id, string name, decimal price, int initialQuantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = initialQuantity < 0 ? 0 : initialQuantity;
        }

        // Encapsulated method to update quantities safely
        public void UpdateQuantity(int amount)
        {
            Quantity += amount;
            if (Quantity < 0) Quantity = 0; // Prevent negative stock
        }

        // Level-Up: Flag if item needs restocking
        public bool NeedsRestock => Quantity < RestockThreshold;

        public override string ToString()
        {
            string alert = NeedsRestock ? " [⚠️ LOW STOCK - RESTOCK ALERT!]" : "";
            return $"ID: {Id} | Name: {Name} | Price: {Price:C} | Qty: {Quantity}{alert}";
        }
    }
}