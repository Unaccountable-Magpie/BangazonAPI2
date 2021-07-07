
﻿//Author: Austin Gorman
//Purpose: To reference the Customers table and it's values


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
    public class Customers
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime LastActivity { get; set; }

        List<Products> ProductsList = new List<Products>();

        List<PaymentTypes> PaymentTypesList = new List<PaymentTypes>();
    }
}