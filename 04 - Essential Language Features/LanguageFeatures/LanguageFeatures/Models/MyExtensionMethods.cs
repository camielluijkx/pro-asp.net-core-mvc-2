using System.Collections.Generic;
using System;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this ShoppingCart cartParam) // Using Extension Methods
        {
            decimal total = 0;

            foreach (Product prod in cartParam.Products)
            {
                total += prod?.Price ?? 0;
            }

            return total;
        }

        public static decimal TotalPrices(this IEnumerable<Product> products) // Applying Extension Methods to an Interface
        {
            decimal total = 0;

            foreach (Product prod in products)
            {
                total += prod?.Price ?? 0;
            }

            return total;
        }

        public static IEnumerable<Product> FilterByPrice(this IEnumerable<Product> productEnum, decimal minimumPrice) // Creating Filtering Extension Methods
        {
            foreach (Product prod in productEnum)
            {
                if ((prod?.Price ?? 0) >= minimumPrice)
                {
                    yield return prod;
                }
            }
        }

        public static IEnumerable<Product> FilterByName(this IEnumerable<Product> productEnum, char firstLetter) // Using lanbda Expressions
        {
            foreach (Product prod in productEnum)
            {
                if (prod?.Name?[0] == firstLetter)
                {
                    yield return prod;
                }
            }
        }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> productEnum, Func<Product, bool> selector) // Using Functions
        {
            foreach (Product prod in productEnum)
            {
                if (selector(prod))
                {
                    yield return prod;
                }
            }
        }
    }
}
