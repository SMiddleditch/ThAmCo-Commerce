using Microsoft.EntityFrameworkCore;
using ThAmCo_Commerce.Models;

namespace ThAmCo_Commerce.Data.Cart
{
    public class ShopCart
    {
        public AppDbContext _context { get; set; }
        public string ProductCartId { get; set; }
        public List<ProductCart> ProductCarts { get; set; }
        public ShopCart(AppDbContext context)
        {
            _context = context;
        }

        // Add product to the shopping cart
        public void AddProductToCart(Product product)
        {
            var ProductCart = _context.ProductCarts.FirstOrDefault(n => n.Product.Id== product.Id && n.ProductCartId == ProductCartId);
            
            if(ProductCart == null) 
            {
                ProductCart = new ProductCart()
                {
                    ProductCartId = ProductCartId,
                    Product = product,
                    Amount = 1
                };
                
                _context.ProductCarts.Add(ProductCart);
            } else
            {
                ProductCart.Amount++;
            }
            _context.SaveChanges();
        }
        // Remove product to the shopping cart
        public void RemoveProductFromCart(Product product) 
        {
            var ProductCart = _context.ProductCarts.FirstOrDefault(n => n.Product.Id == product.Id && n.ProductCartId == ProductCartId);

            if (ProductCart != null)
            {
                if(ProductCart.Amount > 1)
                {
                    ProductCart.Amount--;
                }
                else
                {
                    _context.ProductCarts.Remove(ProductCart);
                }                
            }
            _context.SaveChanges();
        }


        public List<ProductCart> GetProductCarts()
        {
            return ProductCarts ?? (ProductCarts = _context.ProductCarts.Where(n => n.ProductCartId == ProductCartId).Include(nameof => nameof.Product).ToList());
        }

        public double GetProductCartTotal()
        {
            var total = _context.ProductCarts.Where(n => n.ProductCartId == ProductCartId).Select(n => n.Product.ProductPrice * n.Amount).Sum();
            return total;
        }

    }
}
