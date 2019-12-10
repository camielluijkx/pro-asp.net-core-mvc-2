using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models
{
    public class FakeProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product { Name = "Football", Price = 25 },
            new Product { Name = "Surf board", Price = 179 },
            new Product { Name = "Running shoes", Price = 95 }
        };

        public IQueryable<Product> Products
        {
            get
            {
                return _products.AsQueryable<Product>();
            }
        }

        public void SaveProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Product DeleteProduct(int productID)
        {
            throw new System.NotImplementedException();
        }
    }
}