using Microsoft.EntityFrameworkCore;
using MPZ2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZ2.Contexts
{
    public class PositionsContext: DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Positions.db");
        }

        public DbSet<PositionsModel> Positions { get; set; }

    }
}
