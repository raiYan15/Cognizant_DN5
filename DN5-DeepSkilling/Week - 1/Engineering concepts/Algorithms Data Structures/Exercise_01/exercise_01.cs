using System;
using System.Collections.Generic;

namespace InventoryManagementSystem
{
    class Product
    {
        public int ProductId;
        public string ProductName;
        public int Quantity;
        public double Price;

        public Product(int productId, string productName, int quantity, double price)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }

        public void Display()
        {
            Console.WriteLine("Product ID: " + ProductId);
            Console.WriteLine("Product Name: " + ProductName);
            Console.WriteLine("Quantity: " + Quantity);
            Console.WriteLine("Price: " + Price);
            Console.WriteLine("");
        }
    }

    class InventoryManager
    {
        Dictionary<int, Product> inventory = new Dictionary<int, Product>();

        public void AddProduct(Product product)
        {
            if (inventory.ContainsKey(product.ProductId))
            {
                Console.WriteLine("Product already exists.");
            }
            else
            {
                inventory.Add(product.ProductId, product);
                Console.WriteLine("Product added successfully.");
            }
        }

        public void UpdateProduct(int productId, string productName, int quantity, double price)
        {
            if (inventory.ContainsKey(productId))
            {
                Product product = inventory[productId];

                product.ProductName = productName;
                product.Quantity = quantity;
                product.Price = price;

                Console.WriteLine("Product updated successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public void DeleteProduct(int productId)
        {
            if (inventory.ContainsKey(productId))
            {
                inventory.Remove(productId);
                Console.WriteLine("Product deleted successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public void DisplayInventory()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
            }
            else
            {
                foreach (Product product in inventory.Values)
                {
                    product.Display();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            InventoryManager manager = new InventoryManager();

            manager.AddProduct(new Product(101, "Laptop", 50, 999.99));
            manager.AddProduct(new Product(102, "Mouse", 200, 29.99));
            manager.AddProduct(new Product(103, "Keyboard", 150, 79.99));

            Console.WriteLine("\nAll Products:");
            manager.DisplayInventory();

            manager.UpdateProduct(102, "Wireless Mouse", 180, 24.99);

            Console.WriteLine("\nAfter Updating:");
            manager.DisplayInventory();

            manager.DeleteProduct(103);

            Console.WriteLine("\nAfter Deleting:");
            manager.DisplayInventory();

            Console.WriteLine("\nTime Complexity:");
            Console.WriteLine("Add Product: O(1)");
            Console.WriteLine("Update Product: O(1)");
            Console.WriteLine("Delete Product: O(1)");
            Console.WriteLine("Display Products: O(n)");
        }
    }
}