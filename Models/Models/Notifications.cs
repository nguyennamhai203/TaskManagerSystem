using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerModels.Models
{
    public class Notifications
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; } // nguoi nhan thong bao
        public string Content { get; set; }
        public byte IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public Users Users { get; set; }

    }
}
