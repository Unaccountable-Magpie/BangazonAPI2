//Author - Brett Shearin
//Purpose - Reflects the ProductTypes table in the database and its values




using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
    public class ProductTypes
    {
       
        public int Id { get; set; }



        
        public string Name { get; set; }
        


    }
}