using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Controllers
{
    public class Computers
    {
        [Key]
        public int Id { get; set; }





        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DatePurchased { get; set; }

        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DecommisssionedDate { get; set; }
        

        [Required]
        public Boolean Malfunctioned { get; set; }


    }
}