using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
    public class Employees
    {
        
        public int Id { get; set; }

        
        public int DepartmentsId { get; set; }
        public Departments Departments { get; set; }
       
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
      
        public bool Supervisor { get; set; }

    }
}
