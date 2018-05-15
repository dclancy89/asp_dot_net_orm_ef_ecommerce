using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    public class ProductViewModel 
    {
        [Required]
        [Display(Name="Name:")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name="Image (url):")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name="Description:")]
        public string Description { get; set; }

        [Required]
        [Display(Name="Initial Quantity")]
        public int Quantity { get; set; }
    }
}