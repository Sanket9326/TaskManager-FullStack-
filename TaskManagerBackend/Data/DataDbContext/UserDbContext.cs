using Microsoft.EntityFrameworkCore;
using TaskManagerBackend.Data.Entity;
using Task = TaskManagerBackend.Data.Entity.Task;

namespace TaskManagerBackend.Data.DataDbContext
{
    public class UserDbContext : DbContext
    {
       public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

       public DbSet<User> user {  get; set; }
       public DbSet<Admin> admins { get; set; }
       public DbSet<Task> tasks { get; set; }
    }
}
