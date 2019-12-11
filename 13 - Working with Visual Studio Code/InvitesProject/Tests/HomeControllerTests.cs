using Microsoft.AspNetCore.Mvc;
using PartyInvites.Controllers;
using PartyInvites.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void ListActionFiltersNonAttendees()
        {
            // Arrange
            HomeController controller = new HomeController(new FakeRepository());

            // Act
            ViewResult result = controller.ListResponses();

            // Assert
            Assert.Equal(2, (result.Model as IEnumerable<GuestResponse>).Count());
        }
    }
}