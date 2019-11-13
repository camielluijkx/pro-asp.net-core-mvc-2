using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index_1()
        {
            List<string> results = new List<string>();

            foreach (Product p in Product.GetProducts())
            {
                string name = p?.Name; // Using the Null Conditional Operator
                decimal? price = p?.Price; // Value must be nullable
                //DateTime inStockSince = p?.InStockSince; // Will not compile
                string relatedName = p?.Related?.Name; // Chaining the Null Conditional Operator

                results.Add(string.Format("Name: {0}, Price: {1}, Related: {2}", name, price, relatedName));
            }

            return View(results);
        }

        public ViewResult Index_2()
        {
            List<string> results = new List<string>();

            foreach (Product p in Product.GetProducts())
            {
                string name = p?.Name ?? "<No Name>"; // Combining the Conditional and Coalescing Operators
                decimal? price = p?.Price ?? 0;
                string relatedName = p?.Related?.Name ?? "<None>";

                results.Add(string.Format("Name: {0}, Price: {1}, Related: {2}", name, price, relatedName));
            }

            return View(results);
        }

        public ViewResult Index_3()
        {
            List<string> results = new List<string>();

            foreach (Product p in Product.GetProducts())
            {
                string name = p?.Name ?? "<No Name>";
                decimal? price = p?.Price ?? 0;
                string relatedName = p?.Related?.Name ?? "<None>";

                results.Add($"Name: {name}, Price: {price:C2}, Related: {relatedName}"); // Using String Interpolation
            }

            return View(results);
        }

        public ViewResult Index_4()
        {
            Dictionary<string, Product> products_ = new Dictionary<string, Product>
            {
                { "Kayak", new Product { Name = "Kayak", Price = 275M } },
                { "LifeJacket", new Product { Name = "LifeJacket", Price = 48.95M } }
            };

            Dictionary<string, Product> products = new Dictionary<string, Product>
            {
                ["Kayak"] = new Product { Name = "Kayak", Price = 275M }, // Using an Index Initializer
                ["LifeJacket"] = new Product { Name = "LifeJacket", Price = 48.95M }
            };

            return View("Index", products.Keys);
        }

        public ViewResult Index_5()
        {
            object[] data = new object[]
            {
                275M, 29.95M, "apple", "orange", 100, 10
            };

            decimal total = 0;

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] is decimal d) // Using Pattern Matching
                {
                    total += d;
                }
            }

            return View("Index", new string[] { $"Total: {total:C2}" });
        }

        public ViewResult Index_6()
        {
            object[] data = new object[]
            {
                275M, 29.95M, "apple", "orange", 100, 10
            };

            decimal total = 0;

            for (int i = 0; i < data.Length; i++)
            {
                switch (data[i]) // using Pattern Matching in Switch Statements
                {
                    case decimal decimalValue:
                        total += decimalValue;
                        break;
                    case int intValue when intValue > 50:
                        total += intValue;
                        break;
                }
            }

            return View("Index", new string[] { $"Total: {total:C2}" });
        }

        public ViewResult Index_7()
        {
            ShoppingCart cart = new ShoppingCart
            {
                Products = Product.GetProducts()
            };

            decimal cartTotal = cart.TotalPrices();

            return View("Index", new string[] { $"Total: {cartTotal:C2}" });
        }

        public ViewResult Index_8()
        {
            ShoppingCart cart = new ShoppingCart
            {
                Products = Product.GetProducts()
            };

            Product[] productArray =
            {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "LifeJacket", Price = 48.95M }
            };

            decimal cartTotal = cart.TotalPrices(); // Applying Extension Methods to an Interface
            decimal arrayTotal = productArray.TotalPrices();

            return View("Index", new string[] { $"Cart Total: {cartTotal:C2}", $"Array Total: {arrayTotal:C2}" });
        }

        public ViewResult Index_9()
        {
            Product[] productArray =
            {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "LifeJacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19.50M },
                new Product { Name = "Corner flag", Price = 34.95M }
            };

            decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();

            return View("Index", new string[] { $"Total: {arrayTotal:C2}" });
        }

        public ViewResult Index_10()
        {
            Product[] productArray =
            {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "LifeJacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19.50M },
                new Product { Name = "Corner flag", Price = 34.95M }
            };

            decimal priceFilterTotal = productArray.FilterByPrice(20).TotalPrices();
            decimal nameFilterTotal = productArray.FilterByName('S').TotalPrices();

            return View("Index", new string[] { $"Price Total: {priceFilterTotal:C2}", $"Name Total: {nameFilterTotal:C2}" });
        }

        bool FilterByPrice(Product p) // Using Functions
        {
            return (p?.Price ?? 0) >= 20;
        }

        public ViewResult Index_11()
        {
            Product[] productArray =
            {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "LifeJacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19.50M },
                new Product { Name = "Corner flag", Price = 34.95M }
            };

            Func<Product, bool> nameFilter = delegate (Product prod)
            {
                return prod?.Name[0] == 'S';
            };

            decimal priceFilterTotal = productArray.Filter(FilterByPrice).TotalPrices(); // Using Global Function
            decimal nameFilterTotal = productArray.Filter(nameFilter).TotalPrices(); // Using Local Function

            return View("Index", new string[] { $"Price Total: {priceFilterTotal:C2}", $"Name Total: {nameFilterTotal:C2}" });
        }

        public ViewResult Index_12()
        {
            Product[] productArray =
            {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "LifeJacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19.50M },
                new Product { Name = "Corner flag", Price = 34.95M }
            };

            Func<Product, bool> nameFilter = delegate (Product prod)
            {
                return prod?.Name[0] == 'S';
            };

            decimal priceFilterTotal = productArray.Filter(p => (p?.Price ?? 0) >= 20).TotalPrices(); // Using Lambda Expression
            decimal nameFilterTotal = productArray.Filter(p => p?.Name?[0] == 'S').TotalPrices();

            return View("Index", new string[] { $"Price Total: {priceFilterTotal:C2}", $"Name Total: {nameFilterTotal:C2}" });
        }

        public async Task<ViewResult> Index_13()
        {
            long? length = await MyAsyncMethods.GetPageLengthAsync();

            return View(new string[] { $"Length: {length}" });
        }

        public ViewResult Index()
        {
            var product = new { Name = "Kayak", Price = 275M }; // Type Inference or Implicit Typing

            var products = new[] // Using Anonymous Types
            {
                new { Name = "Kayak", Price = 275M },
                new { Name = "Lifejacket", Price = 48.95M },
                new { Name = "Soccer ball", Price = 19.50M },
                new { Name = "Corner flag", Price = 34.95M }
            };

            string[] typeNames = products.Select(p => p.GetType().Name).ToArray();

            return View(products.Select(p => $"{nameof(p.Name)}: {p.Name}, {nameof(p.Price)}: {p.Price}")); // Using Lambda Expressions, Methods and Properties + Getting Property Name
        }
    }
}
