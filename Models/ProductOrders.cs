using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
    public class ProductOrders
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrdersId { get; set; }
        public Orders Orders { get; set; }

        [Required]
        public int ProductsId { get; set; }
        public Products Products { get; set; }
    }
}