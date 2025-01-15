using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerModels.Models
{
    public class ActivityLogs
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; } // người thực hiện hoạt động
        public string Action { get; set; }
        public Guid TargetId { get; set; }
        public string TargetType { get; set; }
        public DateTime Timestamp { get; set; }
        public string Details { get; set; } // thong tin chi tiet cua hoat dong
        public Tasks? Tasks { get; set; }
        public Projects? Projects { get; set; }
        public Users? Users { get; set; }

    }
}
