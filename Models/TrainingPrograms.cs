//Purpose: refrences the TrainingPrograms table in the database. Gets and Sets data that the associated 
// controller will be able to access and use to make the program run.

using System;
using System.Collections.Generic;

namespace BangazonAPI.Models
{
    public class TrainingPrograms
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string ProgramName { get; set; }
        public string MaxAttendees { get; set; }

        public List<Employees> EmployeesTraining = new List<Employees>();
    }
}
