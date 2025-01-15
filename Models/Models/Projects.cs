using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerModels.Models
{
    public class Projects
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } // Trạng thái (Pending, Active, Completed, Cancelled).
        public DateTime CreateTime { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}
