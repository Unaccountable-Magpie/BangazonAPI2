//Author: Austin Gorman
//Purpose: To reference the Employees table and it's values

using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DepartmentsId { get; set; }
        [Required]
        public Departments Department { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public bool Supervisor { get; set; }

    }
}
