using System.ComponentModel.DataAnnotations;

namespace ThAmCo_Commerce.Models
{
    public class ProductCart
    {
        [Key]
        public int Id { get; set; }

        public Product Product { get; set; }
        public double Amount { get; set; }

        public string ProductCartId { get; set; }
    }
}
