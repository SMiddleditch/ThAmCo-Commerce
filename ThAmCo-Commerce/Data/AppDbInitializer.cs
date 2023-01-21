using ThAmCo_Commerce.Models;

namespace ThAmCo_Commerce.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                // Product
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            ProductName = "White T",
                            ProductPrice = 9.99,
                            ProductStock = 5,
                            ProductPictureUrl = "https://cdn.pixabay.com/photo/2017/01/13/04/56/t-shirt-1976334__480.png"
                        },

                    });
                    context.SaveChanges();
                }


            }
        }
    }
}
