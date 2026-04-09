namespace Assignment
{
    internal class Program
    {
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public double Price { get; set; }
            public int Stock { get; set; }
        }

        static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter) // Func<Product, bool> is a delegate that takes a Product and returns a bool
        {
            List<Product> result = new();
            foreach (var p in products)
                if (filter(p)) result.Add(p);
            return result;
        }

        static void PrintProducts(string title, List<Product> products)
        {
            Console.WriteLine($"--- {title} ---");
            foreach (var p in products)
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            Console.WriteLine();
        }


        static void PrintReport(List<Product> products, Action<Product> printer) // Action<Product> is a delegate that takes a Product and returns nothing **void
        {
            foreach (var p in products)
                printer(p);
        }


        static List<TResult> TransformProducts<TResult>(List<Product> products, Func<Product, TResult> func) // Func<Product, TResult> is a delegate that takes a Product and returns a TResult
        {
            List<TResult> result = new();
            foreach (var p in products)
                result.Add(func(p));
            return result;
        }

        static List<Product> FilterProducts(List<Product> products, Predicate<Product> condition) // Predicate<Product> is a delegate that takes a Product and returns a bool, similar to Func<Product, bool> but more readable for conditions
        {
            List<Product> result = new();
            foreach (var p in products)
                if (condition(p)) result.Add(p);
            return result;
        }



        static void Main(string[] args)
        {

            List<Product> catalog = new()
            {
                new Product { Id=1, Name="Laptop", Category="Electronics", Price=1200, Stock=10 },
                new Product { Id=2,Name="Phone", Category="Electronics", Price=800, Stock=25 },
                new Product { Id=3, Name="T-Shirt", Category="Clothing", Price=30, Stock=100 },
                new Product { Id=4, Name="Jeans", Category="Clothing", Price=60, Stock=50 },
                new Product { Id=5, Name="Chocolate", Category="Food", Price=5, Stock=200 },
                new Product { Id=6, Name="Coffee Beans", Category="Food", Price=15, Stock=80 },
                new Product { Id=7, Name="C# Book", Category="Books", Price=45, Stock=30 },
                new Product { Id=8, Name="Novel", Category="Books", Price=20, Stock=60 },
                new Product { Id=9,Name="Headphones", Category="Electronics", Price=150, Stock=40 },
                new Product { Id=10, Name="Jacket", Category="Clothing", Price=120, Stock=15 }
            };


            #region task1

            //var electronics = SearchProducts(catalog, p => p.Category == "Electronics");
            //var cheap = SearchProducts(catalog, p => p.Price < 50);
            //var inStock = SearchProducts(catalog, p => p.Stock > 0);
            //var clothing = SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);
            //PrintProducts("Electronics", electronics);
            //PrintProducts("Under $50", cheap);
            //PrintProducts("In Stock", inStock);
            //PrintProducts("Clothing Under $100", clothing);
            #endregion


            #region task3.1

            //Console.WriteLine("--- Short Report ---");
            //PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));

            //Console.WriteLine("\n--- Detailed Report ---");
            //PrintReport(catalog, p =>
            //    Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}")
            //);
            #endregion

            #region task3.2
            //Console.WriteLine("\n--- Summary List ---");
            //var summary = TransformProducts(catalog, p => $"{p.Name} (${p.Price})");
            //summary.ForEach(Console.WriteLine);

            //Console.WriteLine("\n--- Price Labels ---");
            //var labels = TransformProducts(catalog, p =>
            //    p.Price > 100 ? $"{p.Name}: Expensive!" : $"{p.Name}: Affordable"
            //);
            //labels.ForEach(Console.WriteLine);
            #endregion

            #region task3.3
            //Console.WriteLine("\n--- Low-Stock Alert ---");
            //var lowStock = FilterProducts(catalog, p => p.Stock < 20);
            //foreach (var p in lowStock)
            //    Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!");
            #endregion
        }
    }
}
