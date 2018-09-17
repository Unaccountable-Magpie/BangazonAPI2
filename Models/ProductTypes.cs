using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Controllers
{
    public class ProductTypes
    {
        [Key]
        public int Id { get; set; }



        [Required]
        public string Name { get; set; }
        


    }
}