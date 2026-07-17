using System;
namespace EcommerceSearch{
    class Product{
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public Product(int productId, string productName, string category){
            ProductId = productId;
            ProductName = productName;
            Category = category;
        }
        public override string ToString() =>
            $"[ID: {ProductId}] {ProductName} ({Category})";
    }
    class SearchHelper{
        public static int LinearSearchById(Product[] products, int targetId){
            for (int i = 0; i < products.Length; i++){
                if (products[i].ProductId == targetId)
                    return i;
            }
            return -1; 
        }
        public static int BinarySearchById(Product[] products, int targetId){
            int low = 0, high = products.Length - 1;
            while (low <= high){
                int mid = low + (high - low) / 2; 
                if (products[mid].ProductId == targetId)
                    return mid;
                else if (products[mid].ProductId < targetId)
                    low = mid + 1;
                else
                    high = mid - 1;
            }
            return -1; // not found
        }
    }
    class Program{
        static void Main(string[] args){            
            Product[] catalog = {
                new Product(305, "Sneakers", "Footwear"),
                new Product(101, "T-Shirt", "Clothing"),
                new Product(450, "Watch", "Accessories"),
                new Product(210, "Jeans", "Clothing"),
                new Product(520, "Handbag", "Accessories"),
                new Product(180, "Sunglasses", "Accessories"),
            };
            Product[] sortedCatalog = {
                new Product(101, "T-Shirt", "Clothing"),
                new Product(180, "Sunglasses", "Accessories"),
                new Product(210, "Jeans", "Clothing"),
                new Product(305, "Sneakers", "Footwear"),
                new Product(450, "Watch", "Accessories"),
                new Product(520, "Handbag", "Accessories"),
            };
            int searchId = 210;
            Console.WriteLine("Linear Search");
            int linIdx = SearchHelper.LinearSearchById(catalog, searchId);
            if (linIdx >= 0)
                Console.WriteLine($"Found at index {linIdx}: {catalog[linIdx]}");
            else
                Console.WriteLine("Product not found.");
            Console.WriteLine("\nBinary Search");
            int binIdx = SearchHelper.BinarySearchById(sortedCatalog, searchId);
            if (binIdx >= 0)
                Console.WriteLine($"Found at index {binIdx}: {sortedCatalog[binIdx]}");
            else
                Console.WriteLine("Product not found.");
            Console.WriteLine("\nSearching for non-existent ID 999");
            Console.WriteLine($"Linear: index {SearchHelper.LinearSearchById(catalog, 999)}");
            Console.WriteLine($"Binary: index {SearchHelper.BinarySearchById(sortedCatalog, 999)}");
        }
    }
}