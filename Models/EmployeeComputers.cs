using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonAPI.Models
{
    public class EmployeeComputers
    {
        [Key]
        public int EmployeeComputersId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime AssignmentStartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime AssignmentEndDate { get; set; }

        [Required]
        public int EmployeesId { get; set; }
        public Employees Employees { get; set; }
        public int ComputersId { get; set; } // ? means that the variable can be null
        public Computers Computers { get; set; }
    }
}
