using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThAmCo_Commerce.Models;
using ThAmCo_Commerce.Data.Services;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace ThAmCo_Commerce.Controllers.Tests
{
    [TestClass()]
    public class ProductControllerTests
    {

        [TestMethod()]
        public void FilterTest()
        {
            Product p1 = new Product();
            p1.ProductName = "White shirt";
            Product p2 = new Product();
            p2.ProductName = "Black shirt";
            Product p3 = new Product();
            p3.ProductName = "Green Pant";
            Product p4 = new Product();
            p4.ProductName = "Black Pant";

            // This is going to be the fake return value of GetAllAsync
            List<Product> products = new List<Product>
            {
                p1,p2,p3,p4
            };

            // The Fake interface
            var mockProductService = new Mock<IProductService>();

            // Configuring mockProductService to return "products" list as the response when GetAllAsync is invoked.
            mockProductService.Setup(x => x.GetAllAsync())
            .ReturnsAsync(products);

            var controller = new ProductController(mockProductService.Object);

            // ****** Scenario 1 ********
            // Searching for keyword "shirt"
            ViewResult? result = controller.Filter("shirt").Result as ViewResult;

            List<Product>? model = (List<Product>)result.Model;

            // Should return a list of 2 products since there are 2 products with name "shirt"
            Assert.IsNotNull(model);
            Assert.AreEqual(2, model.Count);

            // ****** Scenario 2 ********
            // Searching for keyword "Green"
            result = controller.Filter("Green").Result as ViewResult;

            model = (List<Product>)result.Model;

            // Should return a list of 1 product since there is 1 products with name "Green"
            Assert.IsNotNull(model);
            Assert.AreEqual(1, model.Count);


            // ****** Scenario 3 ********
            // Searching for keyword "Black"
            result = controller.Filter("Black").Result as ViewResult;

            model = (List<Product>)result.Model;

            // Should return a list of 2 products since there are 2 products with name "Black"
            Assert.IsNotNull(model);
            Assert.AreEqual(2, model.Count);

            // ****** Scenario 4 ********
            // Searching for keyword "trousers"
            result = controller.Filter("trousers").Result as ViewResult;

            model = (List<Product>)result.Model;

            // Should return a list of 0 products since there are no products with name "trousers"
            Assert.IsNotNull(model);
            Assert.AreEqual(0, model.Count);

        }

        [TestMethod()]
        public void CreateTest()
        {
            var mockProductService = new Mock<IProductService>();
            var controller = new ProductController(mockProductService.Object);
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteTestConformation()
        {
            Product d1 = new Product();

            var mockProductService = new Mock<IProductService>();

            mockProductService.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(d1);
            mockProductService.Setup(x => x.DeleteAsync(1)).Verifiable();

            var controller = new ProductController(mockProductService.Object);

            // now act           
            // dot result is is to un wrap the result 
            var result = controller.DeleteConformation(1).Result as RedirectToActionResult;


            // now assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ActionName, "Index");


        }

        [TestMethod()]
        public void DetailsTest()
        {
            // We are going to test 2 scenarios of Details method
            // i. When productDetails returned by GetByIdAsync is not null, it should return product details view
            // ii. When productDetails returned by GetByIdAsync is null, it should return "Empty" view

            // For Sceanrio 1
            Product p1 = new Product();
            p1.ProductName = "Test";

            // For Sceanrio 2
            Product p2 = null;

            // Creating a Fake Interface of ProductService to be passed in to the ProductController constructor
            var mockProductService = new Mock<IProductService>();

            // Configuring mockProductService to return p1 as the response when GetByIdAsync is called with "1" as input
            mockProductService.Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync(p1);

            // Configuring mockProductService to return p2 as the response when GetByIdAsync is called with "1" as input
            mockProductService.Setup(x => x.GetByIdAsync(2))
            .ReturnsAsync(p2);

            var controller = new ProductController(mockProductService.Object);

            // ****** Scenario 1 ********
            // Calling the Details method with input "1"
            ViewResult? result = controller.Details(1).Result as ViewResult;

            // Check if the Model returned is equal to p1 object
            Assert.AreEqual(p1, result.Model);

            // ****** Scenario 2 ********
            // Calling the Details method with input "2"
            result = controller.Details(2).Result as ViewResult;

            // Check if the name of the model returned is "Empty"
            Assert.AreEqual("Empty", result.ViewName);
        }

        [TestMethod()]
        public void EditTest()
        {
            // We are going to test 2 scenarios of Edit method
            // i. When productDetails returned by GetByIdAsync is not null, it should return product details view
            // ii. When productDetails returned by GetByIdAsync is null, it should return "Empty" view

            // For Sceanrio 1
            Product p1 = new Product();
            p1.ProductName = "Test";

            // For Sceanrio 2
            Product p2 = null;

            // Creating a Fake Interface of ProductService to be passed in to the ProductController constructor
            var mockProductService = new Mock<IProductService>();

            // Configuring mockProductService to return p1 as the response when GetByIdAsync is called with "1" as input
            mockProductService.Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync(p1);

            // Configuring mockProductService to return p2 as the response when GetByIdAsync is called with "1" as input
            mockProductService.Setup(x => x.GetByIdAsync(2))
            .ReturnsAsync(p2);

            var controller = new ProductController(mockProductService.Object);

            // ****** Scenario 1 ********
            // Calling the Details method with input "1"
            ViewResult? result = controller.Edit(1).Result as ViewResult;

            // Check if the Model returned is equal to p1 object
            Assert.AreEqual(p1, result.Model);

            // ****** Scenario 2 ********
            // Calling the Details method with input "2"
            result = controller.Edit(2).Result as ViewResult;

            // Check if the name of the model returned is "Empty"
            Assert.AreEqual("Empty", result.ViewName);
        }
    }
}