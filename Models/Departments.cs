
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
    public class Departments
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Budget { get; set; }
        public string Name { get; set; }

    }
}