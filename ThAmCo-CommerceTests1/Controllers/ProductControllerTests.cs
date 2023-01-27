using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThAmCo_Commerce.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThAmCo_Commerce.Data.Services;
using Moq;

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
            var productController = new ProductController((IProductService)mockProductService.Object);
            var result = productController.Details();

            Assert.IsNotNull (result);
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