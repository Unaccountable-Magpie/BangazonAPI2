using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Controllers
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomersId { get; set; }
        public Customers Customers { get; set; }
        public int? PaymentTypesId { get; set; }
        public PaymentTypes PaymentTypes { get; set; }

        List<Products> ProductList = new List<Products>();

    }
}