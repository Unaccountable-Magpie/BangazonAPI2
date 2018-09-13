using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonAPI.Models
{
    public class TrainingPrograms
    {
        [Key]
        public int TrainingProgramsId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Required]
        public string ProgramName { get; set; }
        public string MaxAttendees { get; set; }

        public List<Employees> EmployeesTraining = new List<Employees>();
    }
}
