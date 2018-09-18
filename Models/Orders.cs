<<<<<<< HEAD
﻿using BangazonAPI.Controllers;
=======
﻿//Author: Austin Gorman
//Purpose: To reference the Orders table and it's values

>>>>>>> master
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
    public class Orders
    {
        public int Id { get; set; }

        public int CustomersId { get; set; }
        public Customers Customers { get; set; }
        public int? PaymentTypesId { get; set; }
        public PaymentTypes PaymentTypes { get; set; }

        List<Products> ProductList = new List<Products>();

    }
}