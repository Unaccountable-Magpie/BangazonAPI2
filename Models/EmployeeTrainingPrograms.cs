using BangazonAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//Author: Lauren Richert
//This class references a join table which references the Employees table and the TrainingPrograms table.

namespace BangazonAPI.Controllers
{
    public class EmployeeTrainingPrograms
    {
        
        public int Id { get; set; }

        
        public int EmployeesId { get; set; }
        public Employees Employees { get; set; }

        
        public int TrainingProgramsId { get; set; }
        public TrainingPrograms TrainingPrograms { get; set; }
    }
}
