using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerModels.Models
{
    public class Tasks
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; } = "Open";
        public Guid AssignedTo { get; set; }
        public DateTime DueDate { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 
        public Guid ProjectId { get; set; } 
        public Projects? Projects { get; set; }
        public Users? Users { get; set; }
        public ICollection<Comments> Comments { get; set; }

    }
}
