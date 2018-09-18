using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
//Authors: Jewel Ramirez
//Purpose: To reflect the EmployeeComputers table in the database and all its values
namespace BangazonAPI.Models
{
    public class EmployeeComputers
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime AssignmentStartDate { get; set; }

        
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AssignmentEndDate { get; set; } // ? means that the variable can be null

        [Required]
        public int EmployeesId { get; set; }
        public Employees Employees { get; set; }
        public int ComputersId { get; set; } 
        public Computers Computers { get; set; }
    }
}
