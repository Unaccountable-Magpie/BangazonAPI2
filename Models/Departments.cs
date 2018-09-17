//Author: Austin Gorman
//Purpose: To reference the Departments table and it's values
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
    public class Departments
    {
        public int Id { get; set; }

        public string Budget { get; set; }
        public string Name { get; set; }

        List<Employees> EmployeeList = new List<Employees>();
    }
}