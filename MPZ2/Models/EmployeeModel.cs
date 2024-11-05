using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZ2.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; } 

        public string Name { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;

        public DateTime HireDate { get; set; } 

        public int Salary { get; set; } 
    }
}
