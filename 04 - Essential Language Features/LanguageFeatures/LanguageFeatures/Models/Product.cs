using System;

namespace LanguageFeatures.Models
{
    public class Product
    {
        public Product(bool stock = true) // using Readonly Property through Constructor (and Default Property Value)
        {
            InStock = stock;
        }

        public string Name { get; set; } // Using Automatically Implemented Properties

        public string Category { get; set; } = "Watersports"; // Using Auto-Implement Property Initializers 

        public decimal? Price { get; set; }

        public DateTime InStockSince { get; set; }

        public Product Related { get; set; }

        public bool InStock { get; } // Creating Read-Only Automatically Implemented Properties
        //public bool InStock { get; private set; }

        public bool NameBeginsWithS => Name?[0] == 'S'; // Expressing a Property as a Lambda Expression

        public static Product[] GetProducts()
        {
            Product kayak = new Product // Using Object initializer
            {
                Name = "Kayak",
                Category = "Water Craft", // Overwrite Auto-Implemented Property Initializer
                Price = 275M
            };

            Product lifejacket = new Product(false)
            {
                Name = "Lifejacket",
                Price = 48.95M
            };

            kayak.Related = lifejacket;

            return new Product[] { kayak, lifejacket, null }; // Using Collection Initializer
        }
    }
}
