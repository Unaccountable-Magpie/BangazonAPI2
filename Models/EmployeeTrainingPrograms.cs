using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonAPI.Models
{
    public class EmployeeTrainingPrograms
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmployeesId { get; set; }
        public Employees Employees { get; set; }

        [Required]
        public int TrainingProgramsId { get; set; }
        public TrainingPrograms TrainingPrograms { get; set; }
    }
}
