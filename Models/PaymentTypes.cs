﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
    public class PaymentTypes
    {
       
        public int Id { get; set; }



        
        public int CustomersId { get; set; }
        public Customers Customer { get; set; }
        public string Name { get; set; }
        public int AccountNumber { get; set; }
      
    }
}