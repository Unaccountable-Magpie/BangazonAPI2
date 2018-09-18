<<<<<<< HEAD
﻿using BangazonAPI.Controllers;
=======
﻿//Author: Austin Gorman
//Purpose: To reference the ProductOrders table and it's values

>>>>>>> master
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
    public class ProductOrders
    {
        public int Id { get; set; }

        public int OrdersId { get; set; }
        public Orders Orders { get; set; }

        public int ProductsId { get; set; }
        public Products Products { get; set; }
    }
}