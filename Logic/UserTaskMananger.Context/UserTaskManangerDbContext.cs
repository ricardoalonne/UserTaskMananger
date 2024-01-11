using Microsoft.EntityFrameworkCore;
using UserTaskMananger.Entities;

namespace UserTaskMananger.Context
{
    public class UserTaskManangerDbContext : DbContext
    {
        public UserTaskManangerDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
    }
}
