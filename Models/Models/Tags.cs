using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerModels.Models
{
    public class Tags
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } // "Urgent", "Feature", "Bug"
        public string? Description { get; set; }
    }
}
