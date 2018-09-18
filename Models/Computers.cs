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
       
        public int Id { get; set; }





        
        
        
        public DateTime DatePurchased { get; set; }

       
        public DateTime? DecommisssionedDate { get; set; }
        

        
        public Boolean Malfunctioned { get; set; }
        public Boolean IsDeleted { get; set; }


    }
}