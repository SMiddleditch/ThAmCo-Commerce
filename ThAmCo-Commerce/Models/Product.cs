using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThAmCo_Commerce.Data.Base;
using ThAmCo_Commerce.Data.Enums;

namespace ThAmCo_Commerce.Models
{
    public class Product:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product name is required")]
        public string ProductName { get; set; }

        [Display(Name = "Product Price")]
        [Required(ErrorMessage = "Product price is required")]
        public double ProductPrice { get; set; }

        [Display(Name = "Product Stock Level")]
        [Required(ErrorMessage = "Product stock level is required")]
        public int ProductStock { get; set; }

        [Display(Name = "Product Image")]
        [Required(ErrorMessage = "Product image is required")]

        public string ProductPictureUrl { get; set; }
        public Category Category { get; set; }





    }
}
