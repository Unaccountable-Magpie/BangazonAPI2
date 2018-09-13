using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }

        

        [Required]
        public int ProductTypeId { get; set; }
        public ProductTypes ProductId { get; set; }
        public int CustomersID { get; set; }
        public Customers Customer { get; set; }
        public int Price { get; set; }
        public string Title { get; set; } // ? means that the variable can be null
        public string Description { get; set; }
        public int Quantity { get; set; }


    }
}