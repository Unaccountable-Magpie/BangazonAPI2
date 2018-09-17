using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Controllers
{
    public class PaymentTypes
    {
        [Key]
        public int Id { get; set; }



        [Required]
        public int CustomersId { get; set; }
        public Customers Customer { get; set; }
        public string Name { get; set; }
        public int AccountNumber { get; set; }


    }
}