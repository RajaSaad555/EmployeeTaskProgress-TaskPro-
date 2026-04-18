using EmployeeTaskProgress.Models;
using Microsoft.EntityFrameworkCore;
using EmployeeTaskProgress.Models;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }  // ⚠️ Task ki jagah TaskItem
}