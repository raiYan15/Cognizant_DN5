using System;
namespace SortingCustomerOrders{
    class Order{
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public double TotalPrice { get; set; }
        public Order(int orderId, string customerName, double totalPrice){
            OrderId = orderId;
            CustomerName = customerName;
            TotalPrice = totalPrice;
        }
        public override string ToString() =>
            $"Order#{OrderId} | {CustomerName,-15} | ${TotalPrice:F2}";
    }
    class OrderSorter{
        public static void BubbleSort(Order[] orders){
            int n = orders.Length;
            for (int i = 0; i < n - 1; i++){
                bool swapped = false;
                for (int j = 0; j < n - 1 - i; j++){
                    if (orders[j].TotalPrice > orders[j + 1].TotalPrice){
                        Order temp = orders[j];
                        orders[j] = orders[j + 1];
                        orders[j + 1] = temp;
                        swapped = true;
                    }
                }                
                if (!swapped) break;
            }
        }
        public static void QuickSort(Order[] orders, int low, int high){
            if (low < high){
                int pivotIndex = Partition(orders, low, high);
                QuickSort(orders, low, pivotIndex - 1);
                QuickSort(orders, pivotIndex + 1, high);
            }
        }       
        private static int Partition(Order[] orders, int low, int high){
            double pivot = orders[high].TotalPrice;
            int i = low - 1;
            for (int j = low; j < high; j++){
                if (orders[j].TotalPrice <= pivot){
                    i++;
                    Order temp = orders[i];
                    orders[i] = orders[j];
                    orders[j] = temp;
                }
            }        
            Order swap = orders[i + 1];
            orders[i + 1] = orders[high];
            orders[high] = swap;
            return i + 1;
        }
    }
    class Program{
        static Order[] GetSampleOrders() => new Order[]{
            new Order(1001, "Alice",   340.50),
            new Order(1002, "Bob",     125.00),
            new Order(1003, "Charlie", 780.99),
            new Order(1004, "Diana",    55.25),
            new Order(1005, "Ethan",   490.00),
            new Order(1006, "Fiona",   210.75),
        };
        static void PrintOrders(Order[] orders, string label){
            Console.WriteLine($"\n {label}");
            foreach (var o in orders) Console.WriteLine(o);
        }

        static void Main(string[] args){
            Order[] bubbleOrders = GetSampleOrders();
            PrintOrders(bubbleOrders, "Before Bubble Sort");
            OrderSorter.BubbleSort(bubbleOrders);
            PrintOrders(bubbleOrders, "After Bubble Sort (ascending by TotalPrice)");
            Order[] quickOrders = GetSampleOrders();
            PrintOrders(quickOrders, "Before Quick Sort");
            OrderSorter.QuickSort(quickOrders, 0, quickOrders.Length - 1);
            PrintOrders(quickOrders, "After Quick Sort (ascending by TotalPrice)");
        }
    }
}
