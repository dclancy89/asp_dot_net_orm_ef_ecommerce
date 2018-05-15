using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    public class ProductOrder
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order MyOrder { get; set; }

        public int ProductId { get; set; }
        public Product MyProduct { get; set; }
    }
}