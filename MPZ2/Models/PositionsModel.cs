using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZ2.Models
{
    public class PositionsModel
    {
        [Key]
        public int PositionId { get; set; }


        public string PositionName { get; set; } = string.Empty;
    }
}
