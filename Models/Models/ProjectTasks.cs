using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerModels.Models
{
    public class ProjectTasks
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid TaskId { get; set; }
        public Projects Projects { get; set; }
        public Tasks Tasks { get; set; }
    }
}
