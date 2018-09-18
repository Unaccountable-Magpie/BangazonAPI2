//Author: Austin Gorman
//Purpose: To reference the Employees table and it's values

using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
    public class Employees
    {

        public int Id { get; set; }

        public int DepartmentsId { get; set; }
        public Departments Department { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool Supervisor { get; set; }

    }
}
