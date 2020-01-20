using ControllersAndActions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace ControllersAndActions.Tests
{
    public class ActionTests
    {
        [Fact]
        public void ViewSelected1()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.ReceiveForm2("Adam", "London");

            // Assert
            Assert.Equal("Result", result.ViewName);
        }

        [Fact]
        public void ViewSelected2()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Result();

            // Assert
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void ModelObjectType1()
        {
            // Arrange
            ExampleController controller = new ExampleController();

            // Act
            ViewResult result = controller.Index3();

            // Assert
            Assert.IsType<DateTime>(result.ViewData.Model);
        }

        [Fact]
        public void ModelObjectType2()
        {
            // Arrange
            ExampleController controller = new ExampleController();

            // Act
            ViewResult result = controller.Index5();

            // Assert
            Assert.IsType<string>(result.ViewData["Message"]);
            Assert.Equal("Hello", result.ViewData["Message"]);
            Assert.IsType<DateTime>(result.ViewData["Date"]);
        }

        [Fact]
        public void Redirection1()
        {
            // Arrange
            ExampleController controller = new ExampleController();

            // Act
            RedirectResult result = controller.Redirect1();

            // Assert
            Assert.Equal("/Example/Index", result.Url);
            Assert.False(result.Permanent);
        }

        [Fact]
        public void Redirection2()
        {
            // Arrange
            ExampleController controller = new ExampleController();

            // Act
            RedirectResult result = controller.Redirect2();

            // Assert
            Assert.Equal("/Example/Index", result.Url);
            Assert.True(result.Permanent);
        }

        [Fact]
        public void Redirection3()
        {
            // Arrange
            ExampleController controller = new ExampleController();

            // Act
            RedirectToRouteResult result = controller.Redirect3();

            // Assert
            Assert.False(result.Permanent);
            Assert.Equal("Example", result.RouteValues["controller"]);
            Assert.Equal("Index", result.RouteValues["action"]);
            Assert.Equal("MyID", result.RouteValues["ID"]);
        }

        [Fact]
        public void Redirection4()
        {
            // Arrange
            ExampleController controller = new ExampleController();

            // Act
            RedirectToRouteResult result = controller.Redirect4();

            // Assert
            Assert.True(result.Permanent);
            Assert.Equal("Example", result.RouteValues["controller"]);
            Assert.Equal("Index", result.RouteValues["action"]);
            Assert.Equal("MyID", result.RouteValues["ID"]);
        }

        [Fact]
        public void Redirection5()
        {
            // Arrange
            ExampleController controller = new ExampleController();

            // Act
            RedirectToActionResult result = controller.Redirect5();

            // Assert
            Assert.False(result.Permanent);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void JsonActionMethod()
        {
            // Arrange
            ExampleController controller = new ExampleController();

            // Act 
            JsonResult result = controller.Index6();

            // Assert
            Assert.Equal(new[] { "Alice", "Bob", "Joe" }, result.Value);
        }

        [Fact]
        public void NotFoundActionMethod()
        {
            // Arrange
            ExampleController controller = new ExampleController();

            // Act 
            StatusCodeResult result = controller.Index();
            
            // Assert
            Assert.Equal(404, result.StatusCode);
        }
    }
}