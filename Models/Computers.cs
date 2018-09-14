//Author - Brett Shearin
//Purpose - Refelcts the Computers table in the database and its values



using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
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