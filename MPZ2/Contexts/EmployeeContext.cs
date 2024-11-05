using Microsoft.EntityFrameworkCore;
using MPZ2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZ2.Contexts
{
    public class EmployeeContext: DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Employee.db");
        }

        public DbSet<EmployeeModel> Employees {  get; set; }  

    }
}
