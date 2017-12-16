using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UnitTestProject.Web.Controllers;
using UnitTestProject.Web.Models;
using Xunit;
using System.Linq;

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

        [Fact]
        public void VerifyListProductCount()
        {
            var controller = new HomeController();
            var result = Assert.IsType<ViewResult>(controller.List());
            var model = Assert.IsType<List<Product>>(result.Model);
            Assert.Equal(2,model.Count());
        }
    }
}
