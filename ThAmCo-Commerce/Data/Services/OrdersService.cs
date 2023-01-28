using Microsoft.EntityFrameworkCore;
using ThAmCo_Commerce.Data.Cart;
using ThAmCo_Commerce.Models;

namespace ThAmCo_Commerce.Data.Services
{
    /*public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;
        public OrdersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrderByUserAsync(string userId)
        {
            var orders = await _context.Orders.Include(o => o.OrderProduct).ThenInclude(p => p.Product).Where(u => u.UserId == userId).ToListAsync();
            return orders;
        }

        public async Task StoreOrderAsync(List<ShopCart> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();  

            foreach (var item in items)
            {
                var orderProduct = new OrderProduct()
                {
                    ProductId = item.Product.id,
                    OrderId = order.Id,
                    Price = item.Product.ProductPrice,
                    Amount = item.Amount
                };
                await _context.OrderProducts.AddAsync(orderProduct);
            }
            await _context.SaveChangesAsync();
        }
    }*/
}
