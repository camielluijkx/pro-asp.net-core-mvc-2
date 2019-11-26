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
        /// <summary>
        /// Using SharedRepository to verify result of IRepository.Products get accessor.
        /// </summary>
        [Fact]
        public void IndexActionModelIsComplete_UsingSharedRepository()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            // Assert
            Assert.Equal(SimpleRepository.SharedRepository.Products, model, 
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

        class ModelCompleteFakeRepositoryPricesUpTo275 : IRepository
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

        /// <summary>
        /// Using ModelCompleteFakeRepositoryPricesUpTo275 to verify result of IRepository.Products get accessor.
        /// </summary>
        [Fact]
        public void IndexActionModelIsComplete_UsingModelCompleteFakeRepositoryPricesUpTo275()
        {
            // Arrange
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepositoryPricesUpTo275();

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            // Assert
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

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

        /// <summary>
        /// Using ModelCompleteFakeRepositoryPricesUnder50 to verify result of IRepository.Products get accessor.
        /// </summary>
        [Fact]
        public void IndexActionModelIsCompletePricesUnder50_UsingModelCompleteFakeRepositoryPricesUnder50()
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

        class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Product> Products { get; set; }

            public void AddProduct(Product p)
            {
                // do nothing - not required for test
            }
        }

        /// <summary>
        /// Using ModelCompleteFakeRepository and InlineData to verify result of IRepository.Products get accessor.
        /// </summary>
        [Theory]
        [InlineData(275, 48.95, 19.50, 24.95)]
        [InlineData(5, 48.95, 19.50, 24.95)]
        public void IndexActionModelIsComplete_UsingModelCompleteFakeRepositoryAndInlineData(decimal price1, decimal price2, decimal price3, decimal price4)
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

        public static IEnumerable<object[]> GetProductsForTest()
        {
            yield return new object[] { getProductsWithPricesUnder50() };
            yield return new object[] { getProductsWithPricesOver50 };
        }

        /// <summary>
        /// Using ModelCompleteFakeRepository and MemberData to verify result of IRepository.Products get accessor.
        /// </summary>
        [Theory]
        [MemberData(nameof(GetProductsForTest))]
        public void IndexActionModelIsComplete_UsingModelCompleteFakeRepositoryAndMemberData(Product[] products)
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

        /// <summary>
        /// Using ModelCompleteFakeRepository and ClassData to verify result of IRepository.Products get accessor.
        /// </summary>
        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete_UsingModelCompleteFakeRepositoryAndClassData(Product[] products)
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

        /// <summary>
        /// Using PropertyOnceFakeRepository to verify usage of IRepository.Products get accessor.
        /// </summary>
        [Fact]
        public void RepositoryPropertyCalledOnce_UsingPropertyOnceFakeRepository()
        {
            // Arrange
            var repo = new PropertyOnceFakeRepository();
            var controller = new HomeController { Repository = repo };

            // Act
            var result = controller.Index();

            // Assert
            Assert.Equal(1, repo.PropertyCounter);
        }

        /// <summary>
        /// Using Moq framework to verify result of IRepository.Products get accessor.
        /// </summary>
        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete_UsingMoqFramework(Product[] products)
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

        /// <summary>
        /// Using Moq framework to verify usage of IRepository.Products get accessor.
        /// </summary>
        [Fact]
        public void RepositoryPropertyCalledOnce_UsingMoqFramework()
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