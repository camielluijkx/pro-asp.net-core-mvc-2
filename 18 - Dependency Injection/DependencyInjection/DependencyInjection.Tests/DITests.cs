using DependencyInjection.Controllers;
using DependencyInjection.Infrastructure;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Tests
{
    public class DITests
    {
        //[Fact]
        //public void ControllerTest1()
        //{
        //    // Arrange
        //    var data = new[] { new Product { Name = "Test", Price = 100 } };
        //    var mock = new Mock<IRepository>();
        //    mock.SetupGet(m => m.Products).Returns(data);
        //    HomeController controller = new HomeController
        //    {
        //        Repository = mock.Object
        //    };

        //    // Act
        //    ViewResult result = controller.Index3();

        //    // Assert
        //    Assert.Equal(data, result.ViewData.Model);
        //}

        //[Fact]
        //public void ControllerTest2()
        //{
        //    // Arrange
        //    var data = new[] { new Product { Name = "Test", Price = 100 } };
        //    var mock = new Mock<IRepository>();
        //    mock.SetupGet(m => m.Products).Returns(data);
        //    TypeBroker.SetTestObject(mock.Object);
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.Index3();

        //    // Assert
        //    Assert.Equal(data, result.ViewData.Model);
        //}

        //[Fact]
        //public void ControllerTest3()
        //{
        //    // Arrange
        //    var data = new[] { new Product { Name = "Test", Price = 100 } };
        //    var mock = new Mock<IRepository>();
        //    mock.SetupGet(m => m.Products).Returns(data);
        //    HomeController controller = new HomeController(mock.Object);

        //    // Act
        //    ViewResult result = controller.Index4();

        //    // Assert
        //    Assert.Equal(data, result.ViewData.Model);
        //}
    }
}