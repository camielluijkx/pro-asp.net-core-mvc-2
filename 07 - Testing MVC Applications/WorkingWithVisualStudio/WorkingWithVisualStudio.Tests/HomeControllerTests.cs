using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;
using Moq;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {
        /*
        
        [Fact]
        public void IndexActionModelIsComplete()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            // Assert
            Assert.Equal(SimpleRepository.SharedRepository.Products, model, 
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

        */

        /*
        
        class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Product> Products { get; } = new Product[]
            {
                new Product { Name = "P1", Price = 275M },
                new Product { Name = "P2", Price = 48.95M },
                new Product { Name = "P3", Price = 19.50M },
                new Product { Name = "P3", Price = 34.95M }
            };

            public void AddProduct(Product p)
            {
                // do nothing - not required for test
            }
        }

        [Fact]
        public void IndexActionModelIsComplete()
        {
            // Arrange
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepository();

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            // Assert
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

        */

        /*

        class ModelCompleteFakeRepositoryPricesUnder50 : IRepository
        {
            public IEnumerable<Product> Products { get; } = new Product[]
            {
                new Product { Name = "P1", Price = 5M },
                new Product { Name = "P2", Price = 48.95M },
                new Product { Name = "P3", Price = 19.50M },
                new Product { Name = "P3", Price = 34.95M }
            };

            public void AddProduct(Product p)
            {
                // do nothing - not required for test
            }
        }

        [Fact]
        public void IndexActionModelIsCompletePricesUnder50()
        {
            // Arrange
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepositoryPricesUnder50();

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            // Assert
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

        */

        /*
        
        class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Product> Products { get; set; }

            public void AddProduct(Product p)
            {
                // do nothing - not required for test
            }
        }

        [Theory]
        [InlineData(275, 48.95, 19.50, 24.95)]
        [InlineData(5, 48.95, 19.50, 24.95)]
        public void IndexActionModelIsComplete(decimal price1, decimal price2, decimal price3, decimal price4)
        {
            // Arrange
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepository
            {
                Products = new Product[]
                {
                    new Product { Name = "P1", Price = price1 },
                    new Product { Name = "P2", Price = price2 },
                    new Product { Name = "P3", Price = price3 },
                    new Product { Name = "P4", Price = price4 }
                }
            };

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model
                as IEnumerable<Product>;

            // Assert
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name
                    && p1.Price == p2.Price));
        }

        */

        /*
        
        private static IEnumerable<Product> getProductsWithPricesUnder50()
        {
            decimal[] prices = new decimal[] { 275, 49.95M, 19.50M, 24.95M };

            for (int i = 0; i < prices.Length; i++)
            {
                yield return new Product { Name = $"P{i + 1}", Price = prices[i] };
            }
        }

        private static Product[] getProductsWithPricesOver50 => new Product[]
        {
            new Product { Name = "P1", Price = 5 },
            new Product { Name = "P2", Price = 48.95M },
            new Product { Name = "P3", Price = 19.50M },
            new Product { Name = "P4", Price = 24.95M }
        };

        public static IEnumerator<object[]> GetProductsForTest()
        {
            yield return new object[] { getProductsWithPricesUnder50() };
            yield return new object[] { getProductsWithPricesOver50 };
        }

        [Theory]
        [MemberData(nameof(GetProductsForTest))] // FIX: Specified method is not supported.

        public void IndexActionModelIsComplete(Product[] products)
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);
            var controller = new HomeController { Repository = mock.Object };

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model
                as IEnumerable<Product>;

            // Assert
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name
                    && p1.Price == p2.Price));
        }
    
        */

        /*
        
        class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Product> Products { get; set; }

            public void AddProduct(Product p)
            {
                // do nothing - not required for test
            }
        }

        [Theory]
        [ClassData(typeof(ProductTestData))] // FIX: Show single unit test per dataset.
        public void IndexActionModelIsComplete(Product[] products)
        {
            // Arrange
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepository
            {
                Products = products
            };

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model
                as IEnumerable<Product>;

            // Assert
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name
                    && p1.Price == p2.Price));
        }

        */

        /*

        class PropertyOnceFakeRepository : IRepository
        {
            public int PropertyCounter { get; set; } = 0;

            public IEnumerable<Product> Products
            {
                get
                {
                    PropertyCounter++;

                    return new Product[] { new Product { Name = "P1", Price = 100 } };
                }
            }

            public void AddProduct(Product p)
            {
                // do nothing - not required for test
            }
        }

        [Fact]
        public void RepositoryPropertyCalledOnce()
        {
            // Arrange
            var repo = new PropertyOnceFakeRepository();
            var controller = new HomeController { Repository = repo };

            // Act
            var result = controller.Index();

            // Assert
            Assert.Equal(1, repo.PropertyCounter);
        }

        */

        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete(Product[] products)
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);
            var controller = new HomeController { Repository = mock.Object };

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model
                as IEnumerable<Product>;

            // Assert
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name
                    && p1.Price == p2.Price));
        }

        [Fact]
        public void RepositoryPropertyCalledOnce()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products)
                .Returns(new[] { new Product { Name = "P1", Price = 100 } });
            var controller = new HomeController { Repository = mock.Object };

            // Act
            var result = controller.Index();

            // Assert
            mock.VerifyGet(m => m.Products, Times.Once);
        }
    }
}