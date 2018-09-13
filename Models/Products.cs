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
        public int TypeId { get; set; }
        public ProductTypes ProductId { get; set; }
        public int CustomerID { get; set; }
        public Customers Customer { get; set; }
        public string FirstName { get; set; }
        public int? Price { get; set; }
        public string Title { get; set; } // ? means that the variable can be null
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public List<Products> ProductList = new List<Products>();
        public IEnumerable<Products> Product;

    }
}