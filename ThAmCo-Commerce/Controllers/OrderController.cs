using Microsoft.AspNetCore.Mvc;
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
    }
}
