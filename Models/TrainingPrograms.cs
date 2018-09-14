//Purpose: refrences the TrainingPrograms table in the database. Gets and Sets data that the associated 
// controller will be able to access and use to make the program run.
//Author: Amanda Mitchell
//Models: Used [Key] - unique value for this particular entity
//  [Required] - data is required to make the controllers work. 
/*  [DataType(DataType.Date)]  - signifies that the data is something different than the standard and inside the (),
you are letting it know that the datatype is date*/

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
        public int Id { get; set; }

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
