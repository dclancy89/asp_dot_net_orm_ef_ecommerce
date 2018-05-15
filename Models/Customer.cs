using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace eCommerce.Models
{
    public class Customer {
        [Key]
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public List<Order> Orders { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }
    }
}