namespace Exercise20;

public record Order(int OrderId, string CustomerName, string City, decimal Amount, string Status, DateTime OrderDate);

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 20: LINQ Filtering, Projection & Sorting");
        Console.WriteLine("=================================================\n");

        List<Order> orders = new()
        {
            new(1, "Alice Johnson", "Austin", 450.00m, "Completed", DateTime.Now.AddDays(-10)),
            new(2, "Bob Martinez", "Seattle", 1250.00m, "Completed", DateTime.Now.AddDays(-8)),
            new(3, "Charlie Davis", "Austin", 80.00m, "Pending", DateTime.Now.AddDays(-5)),
            new(4, "Diana Patel", "San Francisco", 720.00m, "Completed", DateTime.Now.AddDays(-4)),
            new(5, "Evan Wright", "Denver", 310.00m, "Cancelled", DateTime.Now.AddDays(-3)),
            new(6, "Fiona Clark", "Austin", 890.00m, "Completed", DateTime.Now.AddDays(-2)),
            new(7, "George Miller", "Seattle", 95.00m, "Completed", DateTime.Now.AddDays(-1))
        };

        // LINQ: Filter Completed orders > $100, sort descending by Amount, and project into custom anonymous object
        var highValueCompletedOrders = orders
            .Where(o => o.Status == "Completed" && o.Amount > 100.00m)
            .OrderByDescending(o => o.Amount)
            .Select(o => new
            {
                o.OrderId,
                o.CustomerName,
                o.City,
                FormattedAmount = $"${o.Amount:N2}",
                DaysAgo = (DateTime.Now - o.OrderDate).Days
            })
            .ToList();

        Console.WriteLine($"[1] Filtered High-Value Completed Orders (> $100.00) Count: {highValueCompletedOrders.Count}\n");
        Console.WriteLine($"{"ID",-5} | {"Customer",-16} | {"City",-14} | {"Amount",-12} | {"Age"}");
        Console.WriteLine(new string('-', 60));

        foreach (var order in highValueCompletedOrders)
        {
            Console.WriteLine($"{order.OrderId,-5} | {order.CustomerName,-16} | {order.City,-14} | {order.FormattedAmount,-12} | {order.DaysAgo} days ago");
        }

        // Aggregate calculations using LINQ
        decimal totalRevenue = orders.Where(o => o.Status == "Completed").Sum(o => o.Amount);
        decimal avgOrder = orders.Where(o => o.Status == "Completed").Average(o => o.Amount);

        Console.WriteLine(new string('-', 60));
        Console.WriteLine($"Total Completed Revenue : ${totalRevenue:N2}");
        Console.WriteLine($"Average Completed Order : ${avgOrder:N2}");
        Console.WriteLine("=================================================");
    }
}
