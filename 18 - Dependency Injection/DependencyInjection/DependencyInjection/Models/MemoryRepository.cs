using System;
using System.Collections.Generic;

namespace DependencyInjection.Models
{
    public class MemoryRepository : IRepository
    {
        //private Dictionary<string, Product> products;

        //public MemoryRepository()
        //{
        //    products = new Dictionary<string, Product>();

        //    new List<Product>
        //    {
        //        new Product { Name = "Kayak", Price = 275M },
        //        new Product { Name = "Lifejacket", Price = 48.95M },
        //        new Product { Name = "Soccer ball", Price = 19.50M }
        //    }.ForEach(p => AddProduct(p));
        //}

        private IModelStorage storage;

        private string guid = Guid.NewGuid().ToString();

        public MemoryRepository(IModelStorage modelStore)
        {
            storage = modelStore;

            new List<Product>
            {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "Lifejacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19.50M }
            }.ForEach(p => AddProduct(p));
        }

        //public IEnumerable<Product> Products
        //{
        //    get
        //    {
        //        return products.Values;
        //    }
        //}

        public IEnumerable<Product> Products
        {
            get
            {
                return storage.Items;
            }
        }

        //public Product this[string name]
        //{
        //    get
        //    {
        //        return products[name];
        //    }
        //}

        public Product this[string name]
        {
            get
            {
                return storage[name];
            }
        }

        //public void AddProduct(Product product)
        //{
        //    products[product.Name] = product;
        //}

        public void AddProduct(Product product)
        {
            storage[product.Name] = product;
        }

        //public void DeleteProduct(Product product)
        //{
        //    products.Remove(product.Name);
        //}

        public void DeleteProduct(Product product)
        {
            storage.RemoveItem(product.Name);
        }

        public override string ToString()
        {
            return guid;
        }
    }
}