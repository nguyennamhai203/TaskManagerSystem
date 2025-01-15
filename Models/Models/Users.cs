using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TaskManagerModels.Models
{
    public class Users : IdentityUser<Guid>
    {
        public string AccountName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public byte Sex { get; set; }
        public byte Status { get; set; }

        // Thêm các trường cho mã xác nhận
        public string? VerificationCode { get; set; }
        public DateTime VerificationCodeExpiry { get; set; }
    }
}
