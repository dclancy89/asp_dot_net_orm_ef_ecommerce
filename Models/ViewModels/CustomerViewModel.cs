using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    public class CustomerViewModel {
        [Required]
        [MinLength(2)]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
    }
}