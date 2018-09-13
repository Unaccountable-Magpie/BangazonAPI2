using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
    public class Orders
    {
        [Key]
        public int sId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Required]
        public int CustomersId { get; set; }
        public Customers Customers { get; set; }
        public int? PaymentTypesId { get; set; } // ? means that the variable can be null
        public PaymentTypes PaymentTypes { get; set; }

        public IEnumerable<OrderProduct> ProductOrders;

    }
}