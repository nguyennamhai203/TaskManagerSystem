using TaskManagerModels.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerTaskAPI.AppDbContext
{
    public class ApplicationDbContext : IdentityDbContext<Users, Roles, Guid>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        //public virtual DbSet<Anh> Anhs { get; set; }
        public virtual DbSet<ActivityLogs> ActivityLogs { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<ProjectTasks> ProjectTasks { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<TaskTags> TaskTags { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=TaskManagerSystemDB1;Trusted_Connection=True;"));
        //}
    }
}
