using Microsoft.EntityFrameworkCore;
using ThAmCo_Commerce.Data.Base;
using ThAmCo_Commerce.Models;

namespace ThAmCo_Commerce.Data.Services
{
    public class ProductService : EntityBaseRepository<Product>, IProductService
    {
        /*private readonly AppDbContext _context;*/

        public ProductService(AppDbContext context) : base(context)
        { 

        }
    }
}
