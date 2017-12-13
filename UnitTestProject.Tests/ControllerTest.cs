using System;
using Microsoft.AspNetCore.Mvc;
using UnitTestProject.Web.Controllers;
using Xunit;

namespace UnitTestProject.Tests
{
    public class ControllerTest
    {
        [Fact]
        public void VerifyIndexViewType()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
