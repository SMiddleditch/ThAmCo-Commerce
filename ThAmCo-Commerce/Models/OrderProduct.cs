using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThAmCo_Commerce.Models
{
    public class OrderProduct
    {
        [Key] 
        public int Id { get; set; }

        public double Amount { get; set; }
        public double Price { get; set; }


        public int ProductId { get; set; }
        [ForeignKey("Id")]
        public Product Product { get; set; }


        public int OrderId { get; set; }
        [ForeignKey("Id")]
        public Order Order { get; set; }
    }
}
