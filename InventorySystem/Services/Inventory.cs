using System;
using System.Collections.Generic;
using System.Linq;
using InventorySystem.Models;

namespace InventorySystem.Services
{
    public class Inventory
    {
        private readonly List<Product> _products = new List<Product>();

        // Add a new product
        public bool AddProduct(Product product)
        {
            // Ensure ID uniqueness
            if (_products.Any(p => p.Id.Equals(product.Id, StringComparison.OrdinalIgnoreCase)))
            {
                return false; 
            }
            _products.Add(product);
            return true;
        }

        // Find a product by ID
        public Product FindProduct(string id)
        {
            return _products.FirstOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        // Update existing product stock
        public bool UpdateStock(string id, int changeAmount)
        {
            var product = FindProduct(id);
            if (product == null) return false;

            product.UpdateQuantity(changeAmount);
            return true;
        }

        // Get all products
        public List<Product> GetAllProducts()
        {
            return _products;
        }
    }
}