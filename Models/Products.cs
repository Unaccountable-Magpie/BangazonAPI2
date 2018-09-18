<<<<<<< HEAD
﻿using BangazonAPI.Models;
=======
﻿//Author - Brett Shearin
// Purpose - Reflects the Products table in the database and its values




>>>>>>> master
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Controllers
{
    public class Products
    {
        
        public int Id { get; set; }
        
<<<<<<< HEAD

        [Required]
        public int ProductTypesId { get; set; }
        public ProductTypes ProductTypes { get; set; }
=======
        public int ProductTypeId { get; set; }
        public ProductTypes ProductTypesId { get; set; }
>>>>>>> master
        public int CustomersId { get; set; }
        public Customers Customer { get; set; }
        public int Price { get; set; }
        public string Title { get; set; } // ? means that the variable can be null
        public string Description { get; set; }
        public int Quantity { get; set; }


    }
}