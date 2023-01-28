using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThAmCo_Commerce.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThAmCo_Commerce.Data.Services;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ThAmCo_Commerce.Models;

namespace ThAmCo_Commerce.Controllers.Tests
{
    [TestClass()]
    public class ProductControllerTests
    {
        Mock mockProductService = new Mock<IProductService>();
        
        [TestMethod()]
        public void ProductControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IndexTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FilterTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest()
        {
            var productController = new ProductController((IProductService)mockProductService.Object);
            var result = productController.Create();

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void CreateTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DetailsTest()
        {
            Product p = new Product();
            p.ProductName = "Test";
            Product p2 = null;
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync(p);
            mockProductService.Setup(x => x.GetByIdAsync(2))
            .ReturnsAsync(p2);
            var controller = new ProductController(mockProductService.Object);
            ViewResult? result = controller.Details(1).Result as ViewResult;
            Assert.AreEqual(p, result.Model);
            result = controller.Details(2).Result as ViewResult;
            Assert.AreEqual("Empty", result.ViewName);
        }

        [TestMethod()]
        public void EditTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteConformationTest()
        {
            Assert.Fail();
        }
    }
}