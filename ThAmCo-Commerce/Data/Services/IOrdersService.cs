using ThAmCo_Commerce.Data.Cart;
using ThAmCo_Commerce.Models;

namespace ThAmCo_Commerce.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShopCart> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrderByUserAsync(string userId);
    }
}
