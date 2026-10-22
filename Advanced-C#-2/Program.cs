namespace Advanced_C__2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> catalog = new List<Product>
            {
                new Product { Id = 1, Name="Laptop", Category="Electronics", Price=1200, Stock=10},
                new Product { Id = 2, Name="Phone", Category="Electronics", Price=800, Stock=25},
                new Product { Id = 3, Name="T-Shirt", Category="Clothing", Price=30, Stock=100},
                new Product { Id = 4, Name="Jeans", Category="Clothing", Price=60, Stock=50},
                new Product { Id = 5, Name="Chocolate", Category="Food", Price=5, Stock=200},
                new Product { Id = 6, Name="Coffee Beans", Category="Food", Price=15, Stock=80},
                new Product { Id = 7, Name="C# Book", Category="Books", Price=45, Stock=30},
                new Product { Id = 8, Name="Novel", Category="Books", Price=20, Stock=60},
                new Product { Id = 9, Name="Headphones", Category="Electronics", Price=150, Stock=40},
                new Product { Id = 10, Name="Jacket", Category="Clothing", Price=120, Stock=15}
            };

            #region task 1: Smart product search

            Console.WriteLine("=== Task 01: Smart Product Search ===");

            Console.WriteLine("\n--- Electronics ---");
            var electronics = SearchProducts(catalog, p => p.Category == "Electronics");
            PrintList(electronics);

            Console.WriteLine("\n--- Under $50 ---");
            var under50 = SearchProducts(catalog, p => p.Price < 50);
            PrintList(under50);

            Console.WriteLine("\n--- In Stock ---");
            var inStock = SearchProducts(catalog, p => p.Stock > 0);
            PrintList(inStock);

            Console.WriteLine("\n--- Clothing Under $100 ---");
            var clothingUnder100 = SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);
            PrintList(clothingUnder100);

            static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
            {
                List<Product> result = new List<Product>();
                foreach (var p in products)
                {
                    if (filter(p))
                    {
                        result.Add(p);
                    }
                }
                return result;
            }

            static void PrintList(List<Product> products)
            {
                foreach (var p in products)
                {
                    Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
                }
            }
            #endregion

            #region Task 3.1: Print Reports

            Console.WriteLine("\n\n=== Task 03: Custom Report Generator ===");
            Console.WriteLine("\n--- Short Report ---");
            PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));

            Console.WriteLine("\n--- Detailed Report ---");
            PrintReport(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));

            static void PrintReport(List<Product> products, Action<Product> printAction)
            {
                foreach (var p in products)
                {
                    printAction(p);
                }
            }

            #endregion

            #region Task 3.2: Transform Products
            Console.WriteLine("\n--- Summary List ---");
            var summaryList = TransformProducts(catalog, p => $"{p.Name} (${p.Price})");
            foreach (var item in summaryList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n--- Price Labels ---");

            static List<string> TransformProducts(List<Product> products, Func<Product, string> transform)
            {
                List<string> result = new List<string>();
                foreach (var p in products)
                {
                    result.Add(transform(p));
                }
                return result;
            }
            #endregion

            #region Task 3.3: Filter Products
            Console.WriteLine("\n--- Low-Stock Alert ---");
            var lowStockProducts = FilterProducts(catalog, p => p.Stock < 20);
            foreach (var p in lowStockProducts)
            {
                Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!");
            }

            static List<Product> FilterProducts(List<Product> products, Predicate<Product> condition)
            {
                List<Product> result = new List<Product>();
                foreach (var p in products)
                {
                    if (condition(p))
                    {
                        result.Add(p);
                    }
                }
                return result;
            }

            #endregion
        }
    }
}
