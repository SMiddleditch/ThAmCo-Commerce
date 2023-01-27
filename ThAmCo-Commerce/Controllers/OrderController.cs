using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ThAmCo_Commerce.Data.Cart;
using ThAmCo_Commerce.Data.Services;
using ThAmCo_Commerce.Data.ViewModels;
using ThAmCo_Commerce.Models;

namespace ThAmCo_Commerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductService _productService;
        private readonly ShopCart _shopCart;
        public OrderController(IProductService productService, ShopCart shopCart)
        {
            _productService = productService;
            _shopCart = shopCart;
        }

        public IActionResult Index()
        {
            var items = _shopCart.GetProductCarts();
            _shopCart.ProductCarts = items;

            var response = new ShopCartVM()
            {
                ShopCart = _shopCart,
                ProductCartTotal = _shopCart.GetProductCartTotal()
            };
            return View(response);
        }

        public async Task<IActionResult> AddItem(int id)
        {
            var item = await _productService.GetByIdAsync(id);

            if (item != null)
            {
                _shopCart.AddProductToCart(item);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveItem(int id)
        {
            var item = await _productService.GetByIdAsync(id);

            if (item != null)
            {
                _shopCart.RemoveProductFromCart(item);
            }
            return RedirectToAction(nameof(Index));
        }
    }
    
}
