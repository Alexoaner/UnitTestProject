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

        [Fact]
        public void VerifyValidIdReturnsProduct()
        {
            var repository = new Mock<IProductRepository>();
            repository.Setup(x => x.GetProductById(It.IsInRange<int>(1,3,Range.Inclusive))).Returns(
                new Product { ID = 1, Name = "Apples", Price = 1.50m                
            });
            var controller = new HomeController(repository.Object);
            var result = Assert.IsType<ViewResult>(controller.Details(1));
            var model = Assert.IsType<Product>(result.Model);
            Assert.Equal("Apples", model.Name);
        }

        [Fact]
        public void VerifyInvalidIdReturnsNotFound()
        {
            var repository = new Mock<IProductRepository>();
            repository.Setup(x => x.GetProductById(It.Is<int>(id => id > 3))).Returns((Product)null);
            var controller = new HomeController(repository.Object);
            var result = Assert.IsType<ViewResult>(controller.Details(4));
            Assert.Null(result.Model);
        }
    }
}
