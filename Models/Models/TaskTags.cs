using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerModels.Models
{
    public class TaskTags
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public Guid TagId { get; set; }
        public Tasks Tasks { get; set; }
        public Tags Tags { get; set; }
    }
}
