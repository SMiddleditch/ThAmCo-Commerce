using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ThAmCo_Commerce.Data;
using ThAmCo_Commerce.Data.Services;
using ThAmCo_Commerce.Models;

namespace ThAmCo_Commerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var searchResult = allProducts.Where(n => n.ProductName.Contains(searchString)).ToList();
                return View("Index", searchResult);
            }
            return View(allProducts);
        }

        /// Get Product's create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProductName,ProductPrice,ProductPictureUrl,ProductStock,Category")] Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _service.AddAsync(product);
            return RedirectToAction(nameof(Index));
        }

        /// Get Product details
        public async Task<IActionResult> Details(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);

            if (productDetails == null) return View("Empty");
            return View(productDetails);
        }

        /// Get Product's Edit
        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);

            if (productDetails == null) return View("Empty");
            return View(productDetails);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID, ProductName,ProductPrice,ProductPictureUrl,ProductStock,Category")] Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            product.Id = id;
            await _service.UpdateAsync(id, product);
            return RedirectToAction(nameof(Index));
        }

        /// Get Product's Delete
        public async Task<IActionResult> Delete(int id)
        {

            var productDetails = await _service.GetByIdAsync(id);

            if (productDetails == null) return View("Empty");
            return View(productDetails);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteConformation(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null) return View("Empty");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
