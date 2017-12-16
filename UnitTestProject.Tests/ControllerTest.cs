using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UnitTestProject.Web.Controllers;
using UnitTestProject.Web.Models;
using Xunit;
using System.Linq;
using UnitTestProject.Web.Infrastructure;
using UnitTestProject.Web.Repositorys;
using Moq;

namespace UnitTestProject.Tests
{
    public class ControllerTest
    {
        [Fact]
        public void VerifyIndexViewType()
        {
            // Arrange
            var repository = new Mock<IProductRepository>();
            var controller = new HomeController(repository.Object);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void VerifyListProductCount()
        {
            var repository = new Mock<IProductRepository>();
            repository.Setup(x => x.ListProducts()).Returns(new List<Product>{
                new Product(), new Product()
            });
            var controller = new HomeController(repository.Object);
            var result = Assert.IsType<ViewResult>(controller.List());
            var model = Assert.IsType<List<Product>>(result.Model);
            Assert.Equal(2,model.Count());
        }
    }
}
