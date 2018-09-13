using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
    public class PaymentTypes
    {
        [Key]
        public int Id { get; set; }



        [Required]
        public int CustomerId { get; set; }
        public Customers Customer { get; set; }
        public string Bank { get; set; }
        public int? AccountNumber { get; set; }
        public string CardType { get; set; } // ? means that the variable can be null

        public IEnumerable<PaymentTypes> PaymentType;

    }
}