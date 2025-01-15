using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TaskManagerModels.Models
{
    public class Roles: IdentityRole<Guid>
    {
        public string? RoleCode { get; set; }
        public string? RoleName { get; set; }
        public int? Status { get; set; }
    }
}
