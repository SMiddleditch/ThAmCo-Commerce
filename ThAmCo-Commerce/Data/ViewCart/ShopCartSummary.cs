using Microsoft.AspNetCore.Mvc;
using ThAmCo_Commerce.Data.Cart;

namespace ThAmCo_Commerce.Data.ViewCart
{
    public class ShopCartSummary : ViewComponent
    {
        private readonly ShopCart _shopCart;

        public ShopCartSummary(ShopCart shopCart)
        {
            _shopCart = shopCart;                
        }

        public IViewComponentResult Invoke()
        {
            var items = _shopCart.GetProductCarts();

            return View(items.Count);
        }
    }
}
