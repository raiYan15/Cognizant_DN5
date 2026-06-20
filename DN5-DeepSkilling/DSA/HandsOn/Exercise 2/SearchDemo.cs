// DSA Exercise 2 - Linear Search and Binary Search on Product array
public class SearchDemo
{
    // Linear Search: O(n) - scans each element sequentially
    public static Product? LinearSearch(Product[] products, int targetId)
    {
        foreach (Product product in products)
        {
            if (product.ProductId == targetId)
                return product;
        }
        return null;
    }

    // Binary Search: O(log n) - requires sorted array by ProductId
    public static Product? BinarySearch(Product[] products, int targetId)
    {
        int left = 0;
        int right = products.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (products[mid].ProductId == targetId)
                return products[mid];

            if (products[mid].ProductId < targetId)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return null;
    }

    public static void Main(string[] args)
    {
        Product[] products =
        {
            new Product(101, "Laptop",  "Electronics"),
            new Product(102, "Mobile",  "Electronics"),
            new Product(103, "Shoes",   "Fashion"),
            new Product(104, "Watch",   "Accessories"),
            new Product(105, "Book",    "Education")
        };

        int searchId = 104;

        Console.WriteLine("Linear Search:");
        Product? result1 = LinearSearch(products, searchId);
        Console.WriteLine(result1 != null ? result1.ToString() : "Product not found");

        Console.WriteLine("\nBinary Search:");
        Product? result2 = BinarySearch(products, searchId);
        Console.WriteLine(result2 != null ? result2.ToString() : "Product not found");
    }
}
